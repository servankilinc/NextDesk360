using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Model.Entities.StockModule;

public class FaultType : IEntity, IActivatableEntity, IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual ICollection<StockGroupFaultTypeMap>? StockGroupFaultTypeMaps { get; set; }
    public virtual ICollection<TicketMovement>? TicketMovements { get; set; }
    public virtual ICollection<StockMovement>? StockMovements { get; set; }
}