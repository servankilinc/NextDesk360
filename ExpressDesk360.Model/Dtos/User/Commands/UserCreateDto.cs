using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.User.Commands
{
    public class UserCreateDto : IDto
    {
        public Guid? CompanyId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public DateTime? HireDate { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).When(v => v.CompanyId.HasValue).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.UserName).NotEmpty().WithMessage("UserName cannot be empty");
            RuleFor(v => v.UserName).MaximumLength(500).WithMessage("UserName cannot exceed 500 characters");
        }
    }
}