using Microsoft.EntityFrameworkCore;
using Service.api.security.register.Entities;

namespace Service.api.security.register
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
