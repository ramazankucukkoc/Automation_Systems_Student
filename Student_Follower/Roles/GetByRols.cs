using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student_Follower.Roles
{
    public static class GetByRols
    {

        public static List<string> Roles(string token)
        {
            List<string> roles = new List<string>();
            var handler = new JwtSecurityTokenHandler();
            var tokenSplits = token.Split('.');
            if (tokenSplits.Length != 3)
            {
                return null;
            }

            var payload = tokenSplits[0];
            var payloadBytes = Convert.FromBase64String(payload);
            var payloadJson = Encoding.UTF8.GetString(payloadBytes);
            var claims = handler.ReadJwtToken(token).Claims;
            foreach (Claim claim in claims)
            {

                roles.Add(claim.Value);
            }
            return roles;
        }

    }
}
