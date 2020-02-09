using System;
using System.Threading.Tasks;
using Moq;
using WebApp.Data;
using WebApp.Data.Repositories;
using WebApp.Dtos;
using WebApp.Services;
using WebApp.Services.Infrastructure;
using WebApp.Services.Mappers;
using Xunit;

namespace WebApp.Tests
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IDatetimeService> _datetimeService;

        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _datetimeService = new Mock<IDatetimeService>();
            _userService = new UserService(_userRepository.Object, _datetimeService.Object); 
        }

        //I mostly test a triggering repo methods... because there is no many business logic in my service

        [Fact]
        public async Task DeleteUserShouldThrowExceptionWhenUserIsNotFound()
        {
            //arrange
            _userRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>((null)));
            //act
            var ex = await Assert.ThrowsAsync<ApplicationException>(() => _userService.DeleteUser(1));
            //assert
            Assert.Equal("User not found",ex.Message);
        }

        [Fact]
        public void GetUserShouldQueryDataWithRepositoryMethod()
        {
            //arrange
            //act
            _userService.GetUser(1);
            //assert
            _userRepository.Verify(a=>a.GetUser(1), Times.Once);
        }

        [Fact]
        public void GetAllUsersShouldQueryDataWithRepositoryMethod()
        {
            //arrange
            //act
            _userService.GetAllUsers();
            //assert
            _userRepository.Verify(a => a.GetAllUsers(), Times.Once);
        }

        [Fact]
        public void CreateUserShouldAddUser()
        {
            //arrange
            var now= DateTimeOffset.Now;
            var user = new UserDto()
            {
                Name = "Joe Doe"
            };
            var userEntity = user.MapToEntity();
            _datetimeService.Setup(d => d.GetDatetimeNow()).Returns(now);
            //act
            _userService.CreateUser(user);
            //assert
            _userRepository.Verify(a => a.CreateUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void DeleteUserShouldDeleteUserWithRepo()
        {
            //arrange
            var now = DateTimeOffset.Now;
            var user = new User {Name = "joe doe"};
            _userRepository.Setup(s => s.GetUser(It.IsAny<int>())).ReturnsAsync(user);
            //act
            _userService.DeleteUser(1);
            //assert
            _userRepository.Verify(a => a.DeleteUser(user), Times.Once);
        }
    }
}
