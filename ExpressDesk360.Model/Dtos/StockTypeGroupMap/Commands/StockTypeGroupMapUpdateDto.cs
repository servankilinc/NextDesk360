using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockTypeGroupMap.Commands
{
    public class StockTypeGroupMapUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int StockTypeId { get; set; }
        public int StockGroupId { get; set; }
    }

    public class StockTypeGroupMapUpdateDtoValidator : AbstractValidator<StockTypeGroupMapUpdateDto>
    {
        public StockTypeGroupMapUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockTypeId).NotNull();
            RuleFor(v => v.StockGroupId).NotNull();
        }
    }
}