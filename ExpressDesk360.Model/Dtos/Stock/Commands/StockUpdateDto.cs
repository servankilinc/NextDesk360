using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Stock.Commands
{
    public class StockUpdateDto : IDto
    {
        public Guid Id { get; set; }
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

    public class StockUpdateDtoValidator : AbstractValidator<StockUpdateDto>
    {
        public StockUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockGroupId).NotNull();
            RuleFor(v => v.StockBrandId).NotNull();
            RuleFor(v => v.Vat).NotNull();
        }
    }
}