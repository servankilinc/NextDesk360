using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyFile.Commands
{
    public class CompanyFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid FileId { get; set; }
    }

    public class CompanyFileUpdateDtoValidator : AbstractValidator<CompanyFileUpdateDto>
    {
        public CompanyFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}