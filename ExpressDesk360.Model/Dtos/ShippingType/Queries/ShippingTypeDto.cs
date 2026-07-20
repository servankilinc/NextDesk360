using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ShippingType.Queries
{
    public class ShippingTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}