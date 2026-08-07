using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockTypeGroupMap : IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public int StockTypeId { get; set; }
    public int StockGroupId { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual StockType? StockType { get; set; }
    public virtual StockGroup? StockGroup { get; set; }
}