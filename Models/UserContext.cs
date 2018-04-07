using Microsoft.EntityFrameworkCore;

namespace Kitties.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> UserItems { get; set; }
    }
}