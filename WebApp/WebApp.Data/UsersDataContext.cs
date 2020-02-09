using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class UsersDataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //move connection string to config
            optionsBuilder.UseSqlServer("Server =.; Database = users; Integrated Security = True;");
        }

        public DbSet<User> Users { get; set; }
    }
}
