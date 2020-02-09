using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Data.Repositories;
using WebApp.Dtos;
using WebApp.Services.Infrastructure;
using WebApp.Services.Mappers;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDatetimeService _datetimeService;
        public UserService(IUserRepository userRepository, IDatetimeService datetimeService)
        {
            _userRepository = userRepository;
            _datetimeService = datetimeService;
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var userEntity = await _userRepository.GetUser(userId);
            return userEntity?.MapToDto();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var usersEntities = await _userRepository.GetAllUsers();
            return usersEntities?.Select(u => u.MapToDto());
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            var userEntity = new User();
            userEntity.Name = user.Name;
            userEntity.LastModified = _datetimeService.GetDatetimeNow();

            var newUser = await _userRepository.CreateUser(userEntity);
            return newUser?.MapToDto();
        }

        public async Task DeleteUser(int userId)
        {
            var userEntity = await _userRepository.GetUser(userId);
            if (userEntity == null) throw new ApplicationException("User not found");
            await _userRepository.DeleteUser(userEntity);
        }
    }
}
