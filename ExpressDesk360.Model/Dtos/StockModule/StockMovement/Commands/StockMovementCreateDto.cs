using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovement.Commands
{
    public class StockMovementCreateDto : IDto
    {
        public Guid StockId { get; set; }
        public int StockMovementTypeId { get; set; }
        public Guid? UserId { get; set; }
        public decimal Quantity { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? TicketMovementId { get; set; }
        public int? WarehouseId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public int? FaultTypeId { get; set; }
        public List<Guid>? StockSerialIds { get; set; }
        public DateTime Date { get; set; }
    }

    public class StockMovementCreateDtoValidator : AbstractValidator<StockMovementCreateDto>
    {
        public StockMovementCreateDtoValidator()
        {
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
            RuleFor(v => v.StockMovementTypeId).NotNull();
            RuleFor(v => v.Quantity).NotNull();
        }
    }
}