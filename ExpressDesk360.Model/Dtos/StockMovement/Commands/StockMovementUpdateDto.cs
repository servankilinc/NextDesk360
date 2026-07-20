using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockMovement.Commands
{
    public class StockMovementUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public int StockMovementTypeId { get; set; }
        public Guid? UserId { get; set; }
        public decimal Quantity { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? TicketMovementId { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime Date { get; set; }
    }

    public class StockMovementUpdateDtoValidator : AbstractValidator<StockMovementUpdateDto>
    {
        public StockMovementUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
            RuleFor(v => v.StockMovementTypeId).NotNull();
            RuleFor(v => v.Quantity).NotNull();
        }
    }
}