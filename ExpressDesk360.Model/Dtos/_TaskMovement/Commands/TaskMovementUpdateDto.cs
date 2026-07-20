using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos._TaskMovement.Commands
{
    public class TaskMovementUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public int TaskMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }

    public class TaskMovementUpdateDtoValidator : AbstractValidator<TaskMovementUpdateDto>
    {
        public TaskMovementUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.TaskMovementTypeId).NotNull();
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}