using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.Model.Entities.ProductionModule;

public class CompanyProductWarranty : IEntity, ISoftDeletableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid CompanyProductId { get; set; }
    public int WarrantyTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Status { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    #region ISoftDeletableEntity
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateUtc { get; set; }
    #endregion

    public virtual CompanyProduct? CompanyProduct { get; set; }
    public virtual WarrantyType? WarrantyType { get; set; }
}