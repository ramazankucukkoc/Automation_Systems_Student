using Core.Security.Jwt;

namespace Application.Features.Auths.Dtos
{
    public class LoginDto
    {
        public AccessToken AccessToken { get; set; }
    }
}
