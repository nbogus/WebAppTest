using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Dtos;

namespace WebApp.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int userId);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> CreateUser(UserDto user);
        Task DeleteUser(int userId);
    }
}