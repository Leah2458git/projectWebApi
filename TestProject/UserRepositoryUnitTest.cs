using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserRepositoryUnitTest
    {
        [Fact]
        public async Task getUser_ValidCredentials_ReturnsUser()
        {
            var user = new User { Email= "t@exaaample.com",Password = "password"};
            var mockContext = new Mock<Shop214928673Context>();
            var users = new List<User>() { user };

            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);
            //Act
            var result = await userRepository.Login(user);
            Assert.Equal(user, result);
        }
        [Fact]
        public async Task getUser_ValidCredentials_ReturnsNull()
        {
            var user = new User { Email = "t@exaaample.com", Password = "password" };
            var user1 = new User { Email = "t1@exaaample.com", Password = "password1" };
            var mockContext = new Mock<Shop214928673Context>();
            var users = new List<User>() { user };

            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);
            //Act
            var result = await userRepository.Login(user1);
            Assert.Null(result);
        }


    }
}
