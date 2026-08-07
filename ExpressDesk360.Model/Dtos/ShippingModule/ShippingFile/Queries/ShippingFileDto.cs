using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Queries
{
    public class ShippingFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ShippingId { get; set; }
        public Guid FileId { get; set; }
    }
}