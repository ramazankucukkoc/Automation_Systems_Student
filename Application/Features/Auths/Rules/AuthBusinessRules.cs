using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Types;
using Core.Domain;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task UserShouldBeExists(User? user)
        {

            if (user == null) throw new BusinessException($"{user.FirstName + " " + user.LastName} Böyle bir kullanıcı yoktur..");

            return Task.CompletedTask;
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException($"{user.FirstName + " " + user.LastName} Şifreniz Yanlıştır Kontrol Ediniz ....");
        }
        public async Task UserEmailShouldBeNotExists(string email)
        {
            User doesExists = await _userRepository.GetAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            if (doesExists != null)
                throw new BusinessException($"Bu {email} başka bir kullanıcı tarafından kullanılmaktadır.");
        }
    }
}
