using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Commands
{
    public class StockGroupFaultTypeMapUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int FaultTypeId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockGroupFaultTypeMapUpdateDtoValidator : AbstractValidator<StockGroupFaultTypeMapUpdateDto>
    {
        public StockGroupFaultTypeMapUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.FaultTypeId).NotNull();
            RuleFor(v => v.StockGroupId).NotNull();
        }
    }
}