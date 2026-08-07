using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Commands
{
    public class StockMovementStockSerialMapUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public Guid StockMovementId { get; set; }
    }

    public class StockMovementStockSerialMapUpdateDtoValidator : AbstractValidator<StockMovementStockSerialMapUpdateDto>
    {
        public StockMovementStockSerialMapUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
            RuleFor(v => v.StockMovementId).NotEqual(Guid.Empty).WithMessage("StockMovementId must be a valid guid value");
        }
    }
}