using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ProjectModule.ProjectStaff.Commands
{
    public class ProjectStaffUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class ProjectStaffUpdateDtoValidator : AbstractValidator<ProjectStaffUpdateDto>
    {
        public ProjectStaffUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.ProjectId).NotEqual(Guid.Empty).WithMessage("ProjectId must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}