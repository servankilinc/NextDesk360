using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands
{
    public class StockGroupBrandMapUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int StockBrandId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockGroupBrandMapUpdateDtoValidator : AbstractValidator<StockGroupBrandMapUpdateDto>
    {
        public StockGroupBrandMapUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockBrandId).GreaterThan(0).WithMessage("StockBrandId must be greater than 0");
            RuleFor(v => v.StockGroupId).GreaterThan(0).WithMessage("StockGroupId must be greater than 0");
        }
    }
}