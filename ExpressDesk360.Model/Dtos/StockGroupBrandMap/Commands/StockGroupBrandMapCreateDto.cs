using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands
{
    public class StockGroupBrandMapCreateDto : IDto
    {
        public int StockBrandId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockGroupBrandMapCreateDtoValidator : AbstractValidator<StockGroupBrandMapCreateDto>
    {
        public StockGroupBrandMapCreateDtoValidator()
        {
            RuleFor(v => v.StockBrandId).GreaterThan(0).WithMessage("StockBrandId must be greater than 0");
            RuleFor(v => v.StockGroupId).GreaterThan(0).WithMessage("StockGroupId must be greater than 0");
        }
    }
}