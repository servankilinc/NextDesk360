using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectModule.ProjectFile.Commands
{
    public class ProjectFileCreateDto : IDto
    {
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
    }

    public class ProjectFileCreateDtoValidator : AbstractValidator<ProjectFileCreateDto>
    {
        public ProjectFileCreateDtoValidator()
        {
            RuleFor(v => v.ProjectId).NotEqual(Guid.Empty).WithMessage("ProjectId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}