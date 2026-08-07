using System.Linq.Expressions;
using ExpressDesk360.DataAccess.Repository;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.DataAccess.Abstract.UserModule;

public interface IRefreshTokenRepository : IRepository<RefreshToken>, IRepositoryAsync<RefreshToken>
{
    void RevokeDeviceRefreshTokens(Expression<Func<RefreshToken, bool>> where);
    Task RevokeDeviceRefreshTokensAsync(Expression<Func<RefreshToken, bool>> where, CancellationToken cancellationToken = default);
}