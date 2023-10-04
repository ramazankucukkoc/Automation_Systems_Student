using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Application.Extensions;
using Core.Domain;
using Core.Mailings;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Command
{
    public class ForgotPasswordCommand:IRequest<bool>
    {
        public ForgotPasswordDto ForgotPasswordDto { get; set; }
        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMailService _mailService;
            private readonly UserBusinessRules _userBusinessRules;

            public ForgotPasswordCommandHandler(IUserRepository userRepository, IMailService mailService, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mailService = mailService;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
            {
                bool IsUSerExists = await _userBusinessRules.UserIdShouldExistsWhenSelected(request.ForgotPasswordDto.Email);
                if (IsUSerExists)
                {
                    User? user = await _userRepository.GetAsync(f => f.Email == request.ForgotPasswordDto.Email);

                    var generatedPassword = RandomPasswordExtensions.RandomPassword();
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(generatedPassword, out passwordHash, out passwordSalt);
                    user.PasswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;
                    await _userRepository.UpdateAsync(user);
                    await _mailService.SendMailAsync(new Mail
                    {
                        ToEmail = user.Email,
                        ToFullName = $"{user.FirstName} ${user.LastName}",
                        Subject = "Forgot Password changed password ECommerce - Ramo",
                        TextBody = "Teşekkürler",
                        HtmlBody = $"Şifre değiştirme işlemleri <strong>Başarılı şekilde bitti yeni şifreiniz:{generatedPassword}</strong>"
                    });
                    return true;
                }
                return false;

            }
        }



    }
}
