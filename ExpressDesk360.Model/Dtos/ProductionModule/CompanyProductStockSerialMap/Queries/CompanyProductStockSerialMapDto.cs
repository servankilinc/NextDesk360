using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Queries
{
    public class CompanyProductStockSerialMapDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyProductId { get; set; }
        public Guid StockSerialId { get; set; }
    }
}