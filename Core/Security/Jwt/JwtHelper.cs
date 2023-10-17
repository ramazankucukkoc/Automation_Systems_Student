﻿using Core.Domain;
using Core.Security.Encryption;
using Core.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //Microsoft.Extensions.Configuration.Binder Get<> işelemlerinde yükleniyor!!!!
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        //public RefreshToken CreateRefreshToken(User user, string ipAddress)
        //{
        //    RefreshToken refreshToken = new()
        //    {
        //        UserId = user.Id,
        //        Token = RandomRefreshToken(),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };
        //    return refreshToken;
        //}

        public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            JwtSecurityTokenHandler handler = new();
            string? token = handler.WriteToken(jwt);
            AccessToken accessToken = new() { Token = token, Expiration = _accessTokenExpiration };
            return accessToken;
        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, IList<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwt = new(
               issuer: tokenOptions.Issuer,
               audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetCliams(user, operationClaims),
                signingCredentials: signingCredentials);
            return jwt;
        }
        private IEnumerable<Claim> SetCliams(User user, IList<OperationClaim> operationClaims)
        {
            List<Claim> claims = new();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName(user.FirstName + " " + user.LastName);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }

        private string RandomRefreshToken()
        {
            byte[] numberByte = new Byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}
