using DTOs;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserRepositoryIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly Shop214928673Context _dbContext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext);
        }


        [Fact]
        public async Task GetUser_ValifCredentials_ReturnsUser()
        {
            var email = "test@gmail.com";
            var password = "password";
            var user = new User { Email = email, Password = password, FirstName = "test", LastName = "test22" };
            var userLogin = new User { Email = email, Password = password, FirstName = null, LastName = null };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var result = await _userRepository.Login(userLogin);

            Assert.NotNull(result);
        }

    }
}
