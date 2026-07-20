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
            RuleFor(v => v.FaultTypeId).NotNull();
            RuleFor(v => v.StockGroupId).NotNull();
        }
    }
}