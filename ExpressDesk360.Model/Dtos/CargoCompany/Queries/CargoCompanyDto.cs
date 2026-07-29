using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.CargoCompany.Queries
{
    public class CargoCompanyDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}