using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContext
{
    public class AcademateDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AcademateDbContext(DbContextOptions<AcademateDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Configuration> Configurations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnUserCreating(modelBuilder);
            OnConfigurationCreating(modelBuilder);
        }

        private static void OnUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Email);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired();


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@admin", UserName = "admin", FirstName = "admin", Password = "admin" }
            );
        }

        private static void OnConfigurationCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>().HasKey(c => c.Key);
            modelBuilder.Entity<Configuration>().HasIndex(c => c.Group);

            modelBuilder.Entity<Configuration>().Property(c => c.Key).HasMaxLength(100);
            modelBuilder.Entity<Configuration>().Property(c => c.Group).HasMaxLength(100);
        }
    }
}
