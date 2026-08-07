using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.Task.Commands
{
    public class TaskUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int? TaskPriorityId { get; set; }
        public Guid? ReferenceId { get; set; }
        public Guid? OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public int LastTaskMovementTypeId { get; set; }
        public string? Description { get; set; }
    }

    public class TaskUpdateDtoValidator : AbstractValidator<TaskUpdateDto>
    {
        public TaskUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(200).WithMessage("Name cannot exceed 200 characters");
            RuleFor(v => v.LastTaskMovementTypeId).NotNull();
        }
    }
}