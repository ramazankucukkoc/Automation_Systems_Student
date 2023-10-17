using Application.Services.Repositories;
using Core.Domain;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> UserIdShouldExistsWhenSelected(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            if (user == null) return false;

            return true;
        }

    }
}
