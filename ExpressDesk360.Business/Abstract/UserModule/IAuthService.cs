using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Auth.Login;
using ExpressDesk360.Model.Auth.Logout;
using ExpressDesk360.Model.Auth.Refresh;
using ExpressDesk360.Model.Auth.SignUp;

namespace ExpressDesk360.Business.Abstract.UserModule;

public interface IAuthService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default);
    Task<Result<SignUpResponse>> SignUpAsync(SignUpRequest signUpRequest, CancellationToken cancellationToken = default);
    Task<Result<RefreshAuthResponse>> RefreshAsync(RefreshAuthRequest refreshAuthRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes the refresh token for a single device and clears the refresh token cookie.
    /// </summary>
    Task<Result> LogoutAsync(LogoutRequest logoutRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes every active refresh token of the user across all devices.
    /// </summary>
    Task<Result> RevokeAllAsync(Guid userId, CancellationToken cancellationToken = default);
}