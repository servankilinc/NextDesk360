using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Commands
{
    public class TaskFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TaskFileUpdateDtoValidator : AbstractValidator<TaskFileUpdateDto>
    {
        public TaskFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}