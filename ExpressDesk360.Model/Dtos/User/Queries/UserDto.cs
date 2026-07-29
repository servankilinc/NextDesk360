using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.User.Queries
{
    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public DateTime? HireDate { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}