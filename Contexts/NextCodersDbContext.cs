using Microsoft.EntityFrameworkCore;
using test_next_coders.Models;

namespace Contexts
{
    public class NextCodersDbContext : DbContext
    {
        public NextCodersDbContext(DbContextOptions<NextCodersDbContext> options)
            : base(options) 
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
