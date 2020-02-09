using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task DeleteUser(User user);
    }
}
