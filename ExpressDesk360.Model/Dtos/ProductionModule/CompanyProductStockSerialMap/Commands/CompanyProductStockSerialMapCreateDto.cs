using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands
{
    public class CompanyProductStockSerialMapCreateDto : IDto
    {
        public Guid CompanyProductId { get; set; }
        public Guid StockSerialId { get; set; }
    }

    public class CompanyProductStockSerialMapCreateDtoValidator : AbstractValidator<CompanyProductStockSerialMapCreateDto>
    {
        public CompanyProductStockSerialMapCreateDtoValidator()
        {
            RuleFor(v => v.CompanyProductId).NotEqual(Guid.Empty).WithMessage("CompanyProductId must be a valid guid value");
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
        }
    }
}