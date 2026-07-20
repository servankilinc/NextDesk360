using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectMovement.Commands
{
    public class ProjectMovementUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public int ProjectMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }

    public class ProjectMovementUpdateDtoValidator : AbstractValidator<ProjectMovementUpdateDto>
    {
        public ProjectMovementUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.ProjectId).NotEqual(Guid.Empty).WithMessage("ProjectId must be a valid guid value");
            RuleFor(v => v.ProjectMovementTypeId).NotNull();
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}