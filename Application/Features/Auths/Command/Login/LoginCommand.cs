using Application.Features.Auths.Rules;
using Application.Services.Users;
using AutoMapper;
using Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Command.Login
{
    public class LoginCommand:IRequest<bool>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
        {
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserService userService, AuthBusinessRules authBusinessRules) 
            {
                _authBusinessRules = authBusinessRules;
                _userService = userService;
            }

            public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetByEmail(request.UserForLoginDto.Email);

                if (user == null)
                {
                    return false;
                }
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);

                return true;
            }
        }

    }
}
