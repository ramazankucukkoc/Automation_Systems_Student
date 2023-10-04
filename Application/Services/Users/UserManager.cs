using Application.Services.Repositories;
using Core.Domain;

namespace Application.Services.Users
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            return user;
        }

        public Task<User> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
