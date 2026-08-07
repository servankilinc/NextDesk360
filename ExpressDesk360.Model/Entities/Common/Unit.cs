using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Model.Entities.Common;

public class Unit : IEntity, IActivatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Stock>? Stocks { get; set; }
}