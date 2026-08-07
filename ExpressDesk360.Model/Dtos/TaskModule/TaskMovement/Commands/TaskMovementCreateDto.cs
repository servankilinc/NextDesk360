using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Commands
{
    public class TaskMovementCreateDto : IDto
    {
        public Guid TaskId { get; set; }
        public int TaskMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }

    public class TaskMovementCreateDtoValidator : AbstractValidator<TaskMovementCreateDto>
    {
        public TaskMovementCreateDtoValidator()
        {
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.TaskMovementTypeId).NotNull();
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}