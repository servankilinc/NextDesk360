using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos._TaskStatus.Commands
{
    public class TaskStatusUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class TaskStatusUpdateDtoValidator : AbstractValidator<TaskStatusUpdateDto>
    {
        public TaskStatusUpdateDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}