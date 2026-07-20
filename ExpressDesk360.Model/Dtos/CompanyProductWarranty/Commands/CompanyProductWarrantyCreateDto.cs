using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands
{
    public class CompanyProductWarrantyCreateDto : IDto
    {
        public Guid CompanyProductId { get; set; }
        public int WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }

    public class CompanyProductWarrantyCreateDtoValidator : AbstractValidator<CompanyProductWarrantyCreateDto>
    {
        public CompanyProductWarrantyCreateDtoValidator()
        {
            RuleFor(v => v.CompanyProductId).NotEqual(Guid.Empty).WithMessage("CompanyProductId must be a valid guid value");
            RuleFor(v => v.WarrantyTypeId).GreaterThan(0).WithMessage("WarrantyTypeId must be greater than 0");
        }
    }
}