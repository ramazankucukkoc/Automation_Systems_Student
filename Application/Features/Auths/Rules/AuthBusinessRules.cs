using Application.Services.Repositories;
using Core.Domain;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<bool> UserShouldBeExists(string email)
        {
            User getByEmail = await _userRepository.GetAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());

            if (getByEmail == null) return false;

            return true;
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Şifre Yanlış");
        }
    }
}
