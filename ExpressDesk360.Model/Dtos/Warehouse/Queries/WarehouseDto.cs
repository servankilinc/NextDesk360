using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Warehouse.Queries
{
    public class WarehouseDto : IDto
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}