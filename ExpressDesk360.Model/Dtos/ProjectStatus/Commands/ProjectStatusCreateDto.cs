using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectStatus.Commands
{
    public class ProjectStatusCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class ProjectStatusCreateDtoValidator : AbstractValidator<ProjectStatusCreateDto>
    {
        public ProjectStatusCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}