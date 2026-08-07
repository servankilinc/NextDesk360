using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockType : IEntity, IImmutableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<StockTypeGroupMap>? StockTypeGroupMaps { get; set; }
}