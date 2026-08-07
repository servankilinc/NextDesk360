using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.TicketModule;

public class TicketStatus : IEntity, IImmutableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ICollection<TicketMovementType>? TicketMovementTypes { get; set; }
}