using DTOs;
using Entities;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> GetUserById(int id);
        Task<User> Login(User newUser);
        Task<User> Register(User user);
        Task<User> updateUser(int id, User newUser);
    }
}