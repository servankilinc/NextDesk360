using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Commands
{
    public class TaskStaffUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class TaskStaffUpdateDtoValidator : AbstractValidator<TaskStaffUpdateDto>
    {
        public TaskStaffUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}