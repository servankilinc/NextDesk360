using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectStaff.Commands
{
    public class ProjectStaffCreateDto : IDto
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class ProjectStaffCreateDtoValidator : AbstractValidator<ProjectStaffCreateDto>
    {
        public ProjectStaffCreateDtoValidator()
        {
            RuleFor(v => v.ProjectId).NotEqual(Guid.Empty).WithMessage("ProjectId must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}