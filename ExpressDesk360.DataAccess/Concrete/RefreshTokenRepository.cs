using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities;

namespace ExpressDesk360.DataAccess.Concrete
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken, AppDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }

        public void RevokeDeviceRefreshTokens(Expression<Func<RefreshToken, bool>> where)
        {
            _context.RefreshTokens.Where(where).ExecuteUpdate(s => s.SetProperty(rt => rt.IsRevoked, true));
            SyncTrackedTokens(where);
        }

        public async Task RevokeDeviceRefreshTokensAsync(Expression<Func<RefreshToken, bool>> where, CancellationToken cancellationToken = default)
        {
            await _context.RefreshTokens.Where(where).ExecuteUpdateAsync(s => s.SetProperty(rt => rt.IsRevoked, true), cancellationToken);
            SyncTrackedTokens(where);
        }

        /// <summary>
        /// ExecuteUpdate writes straight to the database and never touches the change tracker.
        /// Any RefreshToken already loaded in this scope would still hold IsRevoked = false, and a
        /// later SaveChanges could write that stale value back - handing a revoked token back to
        /// the caller. Bring tracked instances in line with what we just wrote.
        /// </summary>
        private void SyncTrackedTokens(Expression<Func<RefreshToken, bool>> where)
        {
            var predicate = where.Compile();

            foreach (var entry in _context.ChangeTracker.Entries<RefreshToken>())
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Added) continue;
                if (!predicate(entry.Entity)) continue;

                entry.Entity.IsRevoked = true;
                // Already persisted by ExecuteUpdate; do not re-write it on the next SaveChanges.
                entry.Property(nameof(RefreshToken.IsRevoked)).IsModified = false;
            }
        }
    }
}