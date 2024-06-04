using System.Text.Json;
using DTOs;
using Entities;
using Repositories;
namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> Login(User newUser)
        {

            return await _userRepository.Login(newUser);

        }

        public async Task<User> Register(User user)
        {
            int isSecure = checkPassword(user.Password);
            if (isSecure > 2)
            {
                try
                {
                    return await _userRepository.Register(user);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return null;
        }

        public async Task<User> updateUser(int id, User newUser)
        {
            int isSecure = checkPassword(newUser.Password);
            if (isSecure > 2)
            {
               return await _userRepository.updateUser(id, newUser);
            }
            else
            {
                return null;
            }
        }

        public int checkPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

        
    }
}

    

