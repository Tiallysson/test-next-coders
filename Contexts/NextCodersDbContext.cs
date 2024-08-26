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
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<TaskModel>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserModel>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    Id = -1,
                    Title = "Manutenção API PetHealth",
                    Description = "Continuar a implementação de algunas rotas de Update e Delete",
                    Status = 0,
                    UserId = 1,
                },

                new TaskModel
                {
                    Id = -2,
                    Title = "Estudos sobre Dependence Injection no C#",
                    Description = "Estudar sobre como implementar injeção de dependência no projeto",
                    Status = 0,
                    UserId = 1,
                },

                new TaskModel
                {
                    Id = -3,
                    Title = "Estudar sobre Autenticação com JWT",
                    Description = "Estudar sobre os paços de implementação do JSON Web Token na minha api To-Do List",
                    Status = 0,
                    UserId = 1,
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
