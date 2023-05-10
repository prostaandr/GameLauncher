using GameLauncher.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data
{
    public class GameLauncherContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SystemRequirements> SystemRequirements { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AvailableApplication> AvailableApplications { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<Order> Orders { get; set; }


        public GameLauncherContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableApplication>()
                    .HasKey(e => new { e.UserId, e.ApplicationId });

            modelBuilder.Entity<WishList>()
                    .HasKey(e => new { e.UserId, e.ApplicationId });

            modelBuilder.Entity<User>()
                    .HasMany(u => u.AvailableApplications)
                    .WithOne(aa => aa.User)
                    .HasForeignKey(aa => aa.UserId);

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.AvailableApplications)
                    .WithOne(aa => aa.Application)
                    .HasForeignKey(aa => aa.ApplicationId);

            modelBuilder.Entity<User>()
                    .HasMany(u => u.WishListApplication)
                    .WithOne(aa => aa.User)
                    .HasForeignKey(aa => aa.UserId);

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.WishListApplications)
                    .WithOne(aa => aa.Application)
                    .HasForeignKey(aa => aa.ApplicationId);

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.Orders)
                    .WithMany(o => o.Applications)
                    .UsingEntity<Dictionary<string, object>>("OrderContent",
                            e => e.HasOne<Order>().WithMany().HasForeignKey("OrderId"),
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"));

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.Languages)
                    .WithMany(l => l.Applications)
                    .UsingEntity<Dictionary<string, object>>("ApplicationLanguage",
                            e => e.HasOne<Language>().WithMany().HasForeignKey("LanguageId"),
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"));

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.Genres)
                    .WithMany(g => g.Applications)
                    .UsingEntity<Dictionary<string, object>>("ApplicationGenre",
                            e => e.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"));

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.Features)
                    .WithMany(f => f.Applications)
                    .UsingEntity<Dictionary<string, object>>("ApplicationFeature",
                            e => e.HasOne<Feature>().WithMany().HasForeignKey("FeatureId"),
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"));

            modelBuilder.Entity<Application>()
                    .HasMany(a => a.Medias)
                    .WithMany(m => m.Applications)
                    .UsingEntity<Dictionary<string, object>>("ApplicationMedia",
                            e => e.HasOne<Media>().WithMany().HasForeignKey("MediaId"),
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"));
        }
    }
}
