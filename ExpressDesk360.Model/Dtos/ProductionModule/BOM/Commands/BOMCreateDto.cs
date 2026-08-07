using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProductionModule.BOM.Commands
{
    public class BOMCreateDto : IDto
    {
        public Guid StockId { get; set; }
        public string? VersionName { get; set; }
        public bool Status { get; set; }
    }

    public class BOMCreateDtoValidator : AbstractValidator<BOMCreateDto>
    {
        public BOMCreateDtoValidator()
        {
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
        }
    }
}