using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketMovement.Queries
{
    public class TicketMovementDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public int TicketMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ShippingId { get; set; }
        public int? FaultTypeId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}