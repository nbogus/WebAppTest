using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDataContext _usersDataContext;
        public UserRepository(UsersDataContext usersDataContext)
        {
            _usersDataContext = usersDataContext;
        }

        public Task<User> GetUser(int userId)
        {
            return _usersDataContext.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == userId);
        }

        public Task<List<User>> GetAllUsers()
        {
            return _usersDataContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        { 
            var newEntity = await _usersDataContext.AddAsync(user);
           await _usersDataContext.SaveChangesAsync();
           return newEntity.Entity;
        }

        public async Task DeleteUser(User user)
        {
            var removedUser = _usersDataContext.Remove(user);
            await _usersDataContext.SaveChangesAsync();
        }
    }
}
