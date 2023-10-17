using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auths;
using Application.Services.Repositories;
using Core.Domain;
using Core.Mailings;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;

namespace Application.Features.Auths.Command.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMailService _mailService;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules,
                IMailService mailService, IAuthService authService)
            {
                _authService = authService;
                _mailService = mailService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);              
                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    TCNo = request.UserForRegisterDto.TCNo,
                    BirthDay = request.UserForRegisterDto.BirthDay,
                    PhoneNo = request.UserForRegisterDto.PhoneNo
                };
                User createdUser = await _userRepository.AddAsync(newUser);
                AccessToken accessToken = await _authService.CreateAccessToken(createdUser);

                //await _mailService.SendMailAsync(new Mail()
                //{
                //    ToEmail = request.UserForRegisterDto.Email,
                //    ToFullName = $"{request.UserForRegisterDto.FirstName} ${request.UserForRegisterDto.LastName}",
                //    Subject = "Kayıt İşlemi gerçekleşti Ögrenci Takip Sistemi",
                //    TextBody = "Teşekkürler kayıt işlemi gerçekleşti.",
                //    HtmlBody = "Kaydetme işlemerini<strong> başarılı şekilde tamamlandı.</strong>"
                //});

                RegisteredDto registeredDto = new() { AccessToken = accessToken };
                return registeredDto;
            }
        }
    }
}
