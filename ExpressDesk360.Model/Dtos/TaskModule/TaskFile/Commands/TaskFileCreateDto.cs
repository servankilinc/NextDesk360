using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Commands
{
    public class TaskFileCreateDto : IDto
    {
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TaskFileCreateDtoValidator : AbstractValidator<TaskFileCreateDto>
    {
        public TaskFileCreateDtoValidator()
        {
            RuleFor(v => v.TaskId).NotEqual(Guid.Empty).WithMessage("TaskId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}