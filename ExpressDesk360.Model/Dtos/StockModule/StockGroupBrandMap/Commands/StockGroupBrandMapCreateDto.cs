using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockGroupBrandMap.Commands
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
            RuleFor(v => v.StockBrandId).NotNull();
            RuleFor(v => v.StockGroupId).NotNull();
        }
    }
}