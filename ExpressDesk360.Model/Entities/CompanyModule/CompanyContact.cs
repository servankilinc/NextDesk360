using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.Model.Entities.CompanyModule;

public class CompanyContact : IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int ContactTypeId { get; set; }
    public string Info { get; set; } = null!;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Company? Company { get; set; }
    public virtual ContactType? ContactType { get; set; }
}