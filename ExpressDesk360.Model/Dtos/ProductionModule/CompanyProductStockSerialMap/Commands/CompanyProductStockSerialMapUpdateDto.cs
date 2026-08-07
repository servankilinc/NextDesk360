using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands
{
    public class CompanyProductStockSerialMapUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyProductId { get; set; }
        public Guid StockSerialId { get; set; }
    }

    public class CompanyProductStockSerialMapUpdateDtoValidator : AbstractValidator<CompanyProductStockSerialMapUpdateDto>
    {
        public CompanyProductStockSerialMapUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.CompanyProductId).NotEqual(Guid.Empty).WithMessage("CompanyProductId must be a valid guid value");
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
        }
    }
}