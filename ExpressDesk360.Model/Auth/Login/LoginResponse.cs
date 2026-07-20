using ExpressDesk360.Core.Utils.Auth;

namespace ExpressDesk360.Model.Auth.Login
{
    public class LoginResponse
    {
        public IList<string>? Roles { get; set; }
        public AccessToken AccessToken { get; set; } = null!;
        public Guid DeviceId { get; set; }
    }

    public class LoginTrustedResponse : LoginResponse
    {
        public string RefreshToken { get; set; } = null!;
    }
}