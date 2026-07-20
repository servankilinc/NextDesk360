using ExpressDesk360.Core.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ExpressDesk360.Core.Utils.HttpContextManager;

namespace ExpressDesk360.DataAccess.Interceptors;

/// <summary>
/// Turns hard deletes into soft deletes and propagates the soft delete to children that are
/// configured with a cascading delete behaviour.
/// <para>
/// Propagation is explicit because EF only cascades to children it already tracks. Repository
/// deletes do not Include children, so without loading them here a deleted parent would leave
/// its children with IsDeleted = false - visible in lists while their parent navigation resolves
/// to null (the parent is filtered out by the global query filter).
/// </para>
/// </summary>
public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextManager _httpContextManager;
    public SoftDeleteInterceptor(IHttpContextManager httpContextManager) => _httpContextManager = httpContextManager;


    #region SYNC VERSION
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return base.SavingChanges(eventData, result);

        ApplySoftDelete(eventData.Context, loadAsync: false, cancellationToken: default).GetAwaiter().GetResult();

        return base.SavingChanges(eventData, result);
    }
    #endregion


    #region ASYNC VERSION
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return await base.SavingChangesAsync(eventData, result, cancellationToken);

        await ApplySoftDelete(eventData.Context, loadAsync: true, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    #endregion


    private async Task ApplySoftDelete(DbContext context, bool loadAsync, CancellationToken cancellationToken)
    {
        var deletedEntries = context.ChangeTracker.Entries<ISoftDeletableEntity>()
            .Where(e => e.State == EntityState.Deleted && e.Entity is not IProjectEntity)
            .ToList();

        if (deletedEntries.Count == 0) return;

        var requesterId = _httpContextManager.GetNameIdentifier();
        string deletedBy = requesterId.IsSuccess ? requesterId.Data : string.Empty;
        DateTime now = DateTime.UtcNow;

        var queue = new Queue<EntityEntry>(deletedEntries);
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);

        while (queue.Count > 0)
        {
            var entry = queue.Dequeue();
            if (!visited.Add(entry.Entity)) continue;

            if (entry.Entity is IProjectEntity) continue;
            if (entry.Entity is not ISoftDeletableEntity softDeletable) continue;

            MarkDeleted(entry, softDeletable, deletedBy, now);

            foreach (var child in await LoadCascadeChildren(entry, loadAsync, cancellationToken))
            {
                if (!visited.Contains(child.Entity)) queue.Enqueue(child);
            }
        }
    }

    private static void MarkDeleted(EntityEntry entry, ISoftDeletableEntity entity, string deletedBy, DateTime now)
    {
        // Modified rather than Deleted: the row stays, only the flags change.
        entry.State = EntityState.Modified;
        entity.DeletedBy = deletedBy;
        entity.IsDeleted = true;
        entity.DeletedDateUtc = now;

        // AuditInterceptor runs before this one and only sees Added/Modified entries, so it never
        // stamps rows that were still in the Deleted state at that point. Stamp them here, and keep
        // the created-* columns out of the UPDATE that the Modified state would otherwise produce.
        if (entry.Entity is IAuditableEntity auditable)
        {
            auditable.UpdatedBy = deletedBy;
            auditable.UpdateDateUtc = now;
            entry.Property(nameof(IAuditableEntity.CreatedBy)).IsModified = false;
            entry.Property(nameof(IAuditableEntity.CreateDateUtc)).IsModified = false;
        }
    }

    /// <summary>
    /// Loads and returns the children reachable through collection navigations whose foreign key
    /// is configured to cascade. Non-cascading relationships are intentionally left alone.
    /// </summary>
    private static async Task<IReadOnlyList<EntityEntry>> LoadCascadeChildren(EntityEntry entry, bool loadAsync, CancellationToken cancellationToken)
    {
        var children = new List<EntityEntry>();

        foreach (var collection in entry.Collections)
        {
            if (collection.Metadata is not INavigation navigation) continue;

            var behavior = navigation.ForeignKey.DeleteBehavior;
            if (behavior != DeleteBehavior.Cascade && behavior != DeleteBehavior.ClientCascade) continue;

            if (!collection.IsLoaded)
            {
                if (loadAsync) await collection.LoadAsync(cancellationToken);
                else collection.Load();
            }

            if (collection.CurrentValue is null) continue;

            foreach (var child in collection.CurrentValue)
            {
                if (child is null) continue;
                children.Add(entry.Context.Entry(child));
            }
        }

        return children;
    }
}
