﻿// <auto-generated />
using System;
using GameLauncher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameLauncher.Data.Migrations
{
    [DbContext(typeof(GameLauncherContext))]
    [Migration("20230510212530_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationFeature", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("ApplicationFeature");
                });

            modelBuilder.Entity("ApplicationGenre", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ApplicationGenre");
                });

            modelBuilder.Entity("ApplicationLanguage", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ApplicationLanguage");
                });

            modelBuilder.Entity("ApplicationMedia", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId", "MediaId");

                    b.HasIndex("MediaId");

                    b.ToTable("ApplicationMedia");
                });

            modelBuilder.Entity("GameLauncher.Model.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int?>("MinimumSystemRequirementsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("RecommendedSystemRequirementsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("MinimumSystemRequirementsId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PublisherId");

                    b.HasIndex("RecommendedSystemRequirementsId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("GameLauncher.Model.AvailableApplication", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("AvailableApplications");
                });

            modelBuilder.Entity("GameLauncher.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FlagUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("GameLauncher.Model.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("GameLauncher.Model.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feature");
                });

            modelBuilder.Entity("GameLauncher.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("GameLauncher.Model.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("GameLauncher.Model.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaType")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("GameLauncher.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GameLauncher.Model.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("GameLauncher.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("GameLauncher.Model.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("GameLauncher.Model.SystemRequirements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DirectX")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Graphics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Network")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemRequirements");
                });

            modelBuilder.Entity("GameLauncher.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GameLauncher.Model.WishList", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("OrderContent", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderContent");
                });

            modelBuilder.Entity("ApplicationFeature", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationGenre", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationLanguage", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApplicationMedia", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.Media", null)
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameLauncher.Model.Application", b =>
                {
                    b.HasOne("GameLauncher.Model.Developer", "Developer")
                        .WithMany("Applications")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("GameLauncher.Model.SystemRequirements", "MinimumSystemRequirements")
                        .WithMany()
                        .HasForeignKey("MinimumSystemRequirementsId");

                    b.HasOne("GameLauncher.Model.Application", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("GameLauncher.Model.Publisher", "Publisher")
                        .WithMany("Applications")
                        .HasForeignKey("PublisherId");

                    b.HasOne("GameLauncher.Model.SystemRequirements", "RecommendedSystemRequirements")
                        .WithMany()
                        .HasForeignKey("RecommendedSystemRequirementsId");

                    b.Navigation("Developer");

                    b.Navigation("MinimumSystemRequirements");

                    b.Navigation("Parent");

                    b.Navigation("Publisher");

                    b.Navigation("RecommendedSystemRequirements");
                });

            modelBuilder.Entity("GameLauncher.Model.AvailableApplication", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", "Application")
                        .WithMany("AvailableApplications")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.User", "User")
                        .WithMany("AvailableApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameLauncher.Model.Order", b =>
                {
                    b.HasOne("GameLauncher.Model.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameLauncher.Model.Promotion", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", "Application")
                        .WithMany("Promotions")
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("GameLauncher.Model.Review", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", "Application")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameLauncher.Model.User", b =>
                {
                    b.HasOne("GameLauncher.Model.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GameLauncher.Model.WishList", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", "Application")
                        .WithMany("WishListApplications")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.User", "User")
                        .WithMany("WishListApplication")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderContent", b =>
                {
                    b.HasOne("GameLauncher.Model.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLauncher.Model.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameLauncher.Model.Application", b =>
                {
                    b.Navigation("AvailableApplications");

                    b.Navigation("Promotions");

                    b.Navigation("Reviews");

                    b.Navigation("WishListApplications");
                });

            modelBuilder.Entity("GameLauncher.Model.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("GameLauncher.Model.Developer", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("GameLauncher.Model.Publisher", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("GameLauncher.Model.User", b =>
                {
                    b.Navigation("AvailableApplications");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("WishListApplication");
                });
#pragma warning restore 612, 618
        }
    }
}