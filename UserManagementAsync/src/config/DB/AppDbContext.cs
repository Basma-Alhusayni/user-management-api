using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

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
                entity.HasIndex(user => user.Email)
                    .IsUnique();
                
                entity.Property(user => user.Address)
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}