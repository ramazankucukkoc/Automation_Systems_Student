using Core.Domain;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);
        Task<User> GetById(int id);
        Task<User> Update(User user);


    }
}
