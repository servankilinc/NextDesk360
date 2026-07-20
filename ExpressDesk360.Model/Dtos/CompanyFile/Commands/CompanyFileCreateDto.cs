using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyFile.Commands
{
    public class CompanyFileCreateDto : IDto
    {
        public Guid CompanyId { get; set; }
        public Guid FileId { get; set; }
    }

    public class CompanyFileCreateDtoValidator : AbstractValidator<CompanyFileCreateDto>
    {
        public CompanyFileCreateDtoValidator()
        {
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}