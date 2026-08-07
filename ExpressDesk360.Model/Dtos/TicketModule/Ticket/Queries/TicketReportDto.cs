using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Queries;

namespace ExpressDesk360.Model.Dtos.TicketModule.Ticket.Queries
{
    public class TicketReportDto : IDto
    {
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public string? TicketTypeName { get; set; }
        public int TicketPriorityId { get; set; }
        public string? TicketPriorityName { get; set; }
        public Guid RequesterId { get; set; }
        public string? RequesterName { get; set; }
        public Guid CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public Guid? CompanyProductId { get; set; }
        public string? CompanyProductName { get; set; }
        public int Number { get; set; }
        public int LastTicketMovementTypeId { get; set; }
        public string? LastTicketMovementTypeName { get; set; }
        public string Title { get; set; } = null!;
        public string? TicketDescription { get; set; }
        public bool RemoteSupport { get; set; }
        public bool UnderWarranty { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<TicketStaffDto>? TicketStaffs { get; set; }
    }
}
