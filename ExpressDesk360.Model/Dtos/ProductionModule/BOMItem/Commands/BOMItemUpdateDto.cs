using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Commands
{
    public class BOMItemUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid BOMId { get; set; }
        public Guid StockId { get; set; }
        public decimal Quantity { get; set; }
    }

    public class BOMItemUpdateDtoValidator : AbstractValidator<BOMItemUpdateDto>
    {
        public BOMItemUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.BOMId).NotEqual(Guid.Empty).WithMessage("BOMId must be a valid guid value");
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
            RuleFor(v => v.Quantity).NotNull();
        }
    }
}