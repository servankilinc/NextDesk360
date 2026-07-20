using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos._TaskPriority.Commands
{
    public class TaskPriorityUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Icon { get; set; }
        public int Value { get; set; }
    }

    public class TaskPriorityUpdateDtoValidator : AbstractValidator<TaskPriorityUpdateDto>
    {
        public TaskPriorityUpdateDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            RuleFor(v => v.Value).GreaterThan(0).WithMessage("Value must be greater than 0");
        }
    }
}