using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketStaff.Queries
{
    public class TicketStaffDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public string? UserFullName { get; set; }
    }
}