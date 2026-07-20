using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Company.Commands
{
    public class CompanyCreateDto : IDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public bool ManagerApproval { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }
}