using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Commands
{
    public class TaskPriorityCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Icon { get; set; }
        public int Value { get; set; }
    }

    public class TaskPriorityCreateDtoValidator : AbstractValidator<TaskPriorityCreateDto>
    {
        public TaskPriorityCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            RuleFor(v => v.Value).GreaterThan(-1).WithMessage("Value must be greater than -1");
        }
    }
}