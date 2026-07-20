using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Stock.Commands
{
    public class StockCreateDto : IDto
    {
        public int StockGroupId { get; set; }
        public int StockBrandId { get; set; }
        public string? ModelName { get; set; }
        public string? ModelCode { get; set; }
        public string? ModelType { get; set; }
        public int? UnitId { get; set; }
        public bool SerialTracking { get; set; }
        public bool VirtualSeries { get; set; }
        public string? SerialNumberStart { get; set; }
        public decimal Vat { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? PurchaseCurrencyId { get; set; }
        public decimal? SalePrice { get; set; }
        public int? SalePriceCurrencyId { get; set; }
    }

    public class StockCreateDtoValidator : AbstractValidator<StockCreateDto>
    {
        public StockCreateDtoValidator()
        {
            RuleFor(v => v.StockGroupId).GreaterThan(0).WithMessage("StockGroupId must be greater than 0");
            RuleFor(v => v.StockBrandId).GreaterThan(0).WithMessage("StockBrandId must be greater than 0");
            RuleFor(v => v.Vat).GreaterThan(0).WithMessage("Vat must be greater than 0");
        }
    }
}