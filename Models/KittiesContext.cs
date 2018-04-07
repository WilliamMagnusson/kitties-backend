using Microsoft.EntityFrameworkCore;

namespace Kitties.Models
{
    public class KittiesContext : DbContext
    {
        public KittiesContext(DbContextOptions<KittiesContext> options) : base(options)
        {
        }
        public DbSet<Kitty> KittyItems { get; set; }
    }
}