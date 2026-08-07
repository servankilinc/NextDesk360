using System.Security.Claims;
using ExpressDesk360.Core.Utils.Auth;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Business.Utils.TokenService;

public interface ITokenService
{
    Result<AccessToken> GenerateAccessToken(IList<Claim> claims);
    Result<RefreshToken> GenerateRefreshToken(User user, string tokenValue, string clientType, Guid? deviceId = default);
    string GenerateRandomNumber();
    string HashToken(string token);
}