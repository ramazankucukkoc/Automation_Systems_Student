using Application.Services.Repositories;
using Core.Domain;
using Core.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Auths
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly TokenOptions _tokenOptions;

        public AuthManager(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IConfiguration configuration)
        {
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            const string tokenOptionsConfigurationSection = "TokenOptions";

            _tokenOptions = configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
                ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IList<OperationClaim> operationClaims = await _userOperationClaimRepository
                .Query()
                .AsNoTracking()
                .Where(p => p.UserId == user.Id)
                .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
                .ToListAsync();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;


        }
    }
}
