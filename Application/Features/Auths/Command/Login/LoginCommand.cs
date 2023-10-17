using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auths;
using Application.Services.Repositories;
using Application.Services.Users;
using Core.Domain;
using Core.Security.Jwt;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Features.Auths.Command.Login
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;

            public LoginCommandHandler(IUserService userService, AuthBusinessRules authBusinessRules, IAuthService authService
              )
            {
                _userService = userService;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {

                User user = await _userService.GetByEmail(request.UserForLoginDto.Email);

                await _authBusinessRules.UserShouldBeExists(user);

                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);

                AccessToken accessToken = await _authService.CreateAccessToken(user);

                return new LoginDto() { AccessToken = accessToken };
            }
        }

    }
}
