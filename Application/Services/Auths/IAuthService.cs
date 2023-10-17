using Core.Domain;
using Core.Security.Jwt;

namespace Application.Services.Auths
{
    public interface IAuthService

    {
        public Task<AccessToken> CreateAccessToken(User user);


    }
}
