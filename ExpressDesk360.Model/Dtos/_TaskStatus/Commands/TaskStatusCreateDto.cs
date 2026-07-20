using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos._TaskStatus.Commands
{
    public class TaskStatusCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class TaskStatusCreateDtoValidator : AbstractValidator<TaskStatusCreateDto>
    {
        public TaskStatusCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}