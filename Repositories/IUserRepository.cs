
using DTOs;
using Entities;


namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> Login(User newUser);
        Task<User> Register(User user);
        Task<User> updateUser(int id, User newUser);
    }
}