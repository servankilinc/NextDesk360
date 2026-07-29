using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectMovementType.Commands
{
    public class ProjectMovementTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public int ProjectStatusId { get; set; }
        public bool Accessible { get; set; }
        public string Color { get; set; } = null!;
        public string? InformationText { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class ProjectMovementTypeCreateDtoValidator : AbstractValidator<ProjectMovementTypeCreateDto>
    {
        public ProjectMovementTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
            RuleFor(v => v.ProjectStatusId).NotNull();
            RuleFor(v => v.Color).NotEmpty().WithMessage("Color cannot be empty");
            RuleFor(v => v.Color).MaximumLength(500).WithMessage("Color cannot exceed 500 characters");
        }
    }
}