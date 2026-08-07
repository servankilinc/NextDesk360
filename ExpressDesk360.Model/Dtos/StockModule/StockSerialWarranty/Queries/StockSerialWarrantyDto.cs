using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockSerialWarranty.Queries
{
    public class StockSerialWarrantyDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public int WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}