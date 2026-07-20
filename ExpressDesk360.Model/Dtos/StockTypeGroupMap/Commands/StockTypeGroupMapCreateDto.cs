using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockTypeGroupMap.Commands
{
    public class StockTypeGroupMapCreateDto : IDto
    {
        public int StockTypeId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockTypeGroupMapCreateDtoValidator : AbstractValidator<StockTypeGroupMapCreateDto>
    {
        public StockTypeGroupMapCreateDtoValidator()
        {
            RuleFor(v => v.StockTypeId).GreaterThan(0).WithMessage("StockTypeId must be greater than 0");
            RuleFor(v => v.StockGroupId).GreaterThan(0).WithMessage("StockGroupId must be greater than 0");
        }
    }
}