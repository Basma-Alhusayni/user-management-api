using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.Id);

                entity.Property(user => user.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(user => user.Email)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.HasIndex(user => user.Email).IsUnique();

                entity.Property(user => user.Address)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasOne(u => u.Profile)
                      .WithOne(p => p.User)
                      .HasForeignKey<Profile>(p => p.UserId);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(profile => profile.Id);
                entity.Property(profile => profile.Bio).HasMaxLength(200);
                entity.Property(profile => profile.PhoneNumber).HasMaxLength(20);
            });
        }
    }
}
