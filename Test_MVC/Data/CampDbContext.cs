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

        public DbSet<Camera> Camera { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Open_Event> Open_Events { get; set; }
        public DbSet<SponsorOpenEvent> SponsorOpenEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Shop>()
            .HasMany(s => s.Products)
            .WithOne(s => s.Shop);

            builder.Entity<Camera>()
            .HasMany(c => c.CameraUsages)
            .WithOne(c => c.Camera);

            builder.Entity<Sponsor>()
            .HasMany(s => s.SponsorOpenEvents)
            .WithOne(s => s.Sponsor);

            builder.Entity<Open_Event>()
            .HasMany(c => c.SponsorOpenEvents)
            .WithOne(c => c.OpenEvent);
        }

        public DbSet<Test_MVC.Models.Close_Event>? Close_Event { get; set; }

        public DbSet<Test_MVC.Models.CameraOperator>? CameraOperator { get; set; }

        public DbSet<Test_MVC.Models.MusicConsoleOperator>? MusicConsoleOperator { get; set; }
    }
}