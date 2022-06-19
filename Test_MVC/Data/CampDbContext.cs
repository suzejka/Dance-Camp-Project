using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_MVC.Models;

namespace Test_MVC.Data
{
    public class CampDbContext : DbContext
    {
        public CampDbContext(DbContextOptions<CampDbContext> options)
            : base(options)
        {
        }

        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Camera> Camera { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Shop>()
            .HasMany(s => s.Products)
            .WithOne(s => s.Shop)
            .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Camera>()
            .HasMany(c => c.CameraUsages)
            .WithOne(c => c.Camera)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}