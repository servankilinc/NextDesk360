using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectModule.ProjectFile.Commands
{
    public class ProjectFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
    }

    public class ProjectFileUpdateDtoValidator : AbstractValidator<ProjectFileUpdateDto>
    {
        public ProjectFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.ProjectId).NotEqual(Guid.Empty).WithMessage("ProjectId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}