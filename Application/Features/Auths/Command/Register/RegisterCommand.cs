using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Domain;
using Core.Mailings;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Auths.Command.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMailService _mailService;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules,IMailService mailService)
            {
                _mailService=mailService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                bool IsUserExists = await _authBusinessRules.UserShouldBeExists(request.UserForRegisterDto.Email);
                if (IsUserExists)
                {
                    return false;
                }

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);


                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName
                };
                await _userRepository.AddAsync(newUser);
                await _mailService.SendMailAsync(new Mail()
                {
                    ToEmail = request.UserForRegisterDto.Email,
                    ToFullName = $"{request.UserForRegisterDto.FirstName} ${request.UserForRegisterDto.LastName}",
                    Subject = "Kayıt İşlemi gerçekleşti Ögrenci Takip Sistemi",
                    TextBody="Teşekkürler kayıt işlemi gerçekleşti.",
                    HtmlBody = "Kaydetme işlemerini<strong> başarılı şekilde tamamlandı.</strong>"
                }) ;
                return true;
            }
        }
    }
}
