using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Commands
{
    public class TaskStaffCreateDto : IDto
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class TaskStaffCreateDtoValidator : AbstractValidator<TaskStaffCreateDto>
    {
        public TaskStaffCreateDtoValidator()
        {
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}