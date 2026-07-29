using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockSerial.Queries
{
    public class StockSerialDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? SerialNumber { get; set; }
        public Guid? CompanyId { get; set; }
        public int? WarehouseId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}