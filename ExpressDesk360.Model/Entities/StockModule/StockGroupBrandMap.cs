using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockGroupBrandMap : IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public int StockBrandId { get; set; }
    public int StockGroupId { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual StockBrand? StockBrand { get; set; }
    public virtual StockGroup? StockGroup { get; set; }
}