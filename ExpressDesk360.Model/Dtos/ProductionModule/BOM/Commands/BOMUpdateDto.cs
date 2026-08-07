using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProductionModule.BOM.Commands
{
    public class BOMUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? VersionName { get; set; }
        public bool Status { get; set; }
    }

    public class BOMUpdateDtoValidator : AbstractValidator<BOMUpdateDto>
    {
        public BOMUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
        }
    }
}