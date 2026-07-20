using FluentValidation;

namespace ExpressDesk360.Model.Auth.Logout
{
    public class LogoutRequest
    {
        /// <summary>Optional. When omitted the value is read from the refresh token cookie.</summary>
        public string? RefreshToken { get; set; }
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
    }

    public class LogoutRequestValidator : AbstractValidator<LogoutRequest>
    {
        public LogoutRequestValidator()
        {
            RuleFor(b => b.UserId).NotEmpty();
            RuleFor(b => b.DeviceId).NotEqual(Guid.Empty).NotEmpty();
        }
    }
}
