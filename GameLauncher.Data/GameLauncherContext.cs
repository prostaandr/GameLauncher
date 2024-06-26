﻿using GameLauncher.Model;
using GameLauncher.Model.Enum;
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
        public DbSet<Order> Orders { get; set; }

        public GameLauncherContext()
        {

        }

        public GameLauncherContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                    .HasIndex(r => new { r.UserId, r.ApplicationId })
                    .IsUnique();

            modelBuilder.Entity<User>()
                    .HasMany(u => u.AvailableApplications)
                    .WithMany(a => a.Users)
                    .UsingEntity<Dictionary<string, object>>("AvailableApplications",
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"),
                            e => e.HasOne<User>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                    .HasMany(u => u.WishListApplications)
                    .WithMany(a => a.Users)
                    .UsingEntity<Dictionary<string, object>>("WishListApplications",
                            e => e.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"),
                            e => e.HasOne<User>().WithMany().HasForeignKey("UserId"));



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

            modelBuilder.Entity<Application>()
                    .HasOne(a => a.MinimumSystemRequirements)
                    .WithMany(s => s.MinApplications)
                    .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Application>()
                    .HasOne(a => a.RecommendedSystemRequirements)
                    .WithMany(s => s.RecApplications)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Application>()
                    .Property(a => a.ApplicationType)
                    .HasConversion<string>();

            modelBuilder.Entity<Media>()
                    .Property(m => m.MediaType)
                    .HasConversion<string>();

            modelBuilder.Entity<Review>()
                    .Property(r => r.Grade)
                    .HasConversion<string>();

            modelBuilder.Entity<User>()
                   .Property(u => u.Role)
                   .HasConversion<string>();


        }
    }
}
