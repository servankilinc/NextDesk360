using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Commands
{
    public class StockMovementStockSerialMapCreateDto : IDto
    {
        public Guid StockSerialId { get; set; }
        public Guid StockMovementId { get; set; }
    }

    public class StockMovementStockSerialMapCreateDtoValidator : AbstractValidator<StockMovementStockSerialMapCreateDto>
    {
        public StockMovementStockSerialMapCreateDtoValidator()
        {
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
            RuleFor(v => v.StockMovementId).NotEqual(Guid.Empty).WithMessage("StockMovementId must be a valid guid value");
        }
    }
}