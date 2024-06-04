using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {

        private Shop214928673Context _shop;

        public UserRepository(Shop214928673Context shop)
        {
            _shop = shop;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _shop.Users.FindAsync(id);
        }

        

        public async Task<User> Login(User newUser)
        {
           return await _shop.Users.Where(user => user.Email == newUser.Email && user.Password == newUser.Password).FirstOrDefaultAsync();
        }


        public async Task<User> Register(User user)
        {
            await _shop.Users.AddAsync(user);
            await _shop.SaveChangesAsync();
            return user;
        }



        public async Task<User> updateUser(int id, User newUser)
        {
            newUser.UserId = id;
            _shop.Users.Update(newUser);
            await _shop.SaveChangesAsync();
            return newUser;

        }



        
    }
}

