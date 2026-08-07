using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockMovementType : IEntity, IImmutableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public char InOutCode { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<StockMovement>? StockMovements { get; set; }
}