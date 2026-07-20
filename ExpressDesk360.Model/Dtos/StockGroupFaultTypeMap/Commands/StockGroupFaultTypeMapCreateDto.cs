using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Commands
{
    public class StockGroupFaultTypeMapCreateDto : IDto
    {
        public int FaultTypeId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockGroupFaultTypeMapCreateDtoValidator : AbstractValidator<StockGroupFaultTypeMapCreateDto>
    {
        public StockGroupFaultTypeMapCreateDtoValidator()
        {
            RuleFor(v => v.FaultTypeId).GreaterThan(0).WithMessage("FaultTypeId must be greater than 0");
            RuleFor(v => v.StockGroupId).GreaterThan(0).WithMessage("StockGroupId must be greater than 0");
        }
    }
}