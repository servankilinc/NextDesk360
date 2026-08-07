using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketModule.Ticket.Queries
{
    public class TicketDto : IDto
    {
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public Guid RequesterId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public int Number { get; set; }
        public int LastTicketMovementTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string? TicketDescription { get; set; }
        public bool RemoteSupport { get; set; }
        public bool UnderWarranty { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
    }
}