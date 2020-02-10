﻿// <auto-generated />
using System;
using Klimatkollen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Klimatkollen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200210142602_newmigration")]
    partial class newmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Klimatkollen.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MainCategoryId");

                    b.Property<string>("Type");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Vind",
                            Unit = "m/s"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Temperatur",
                            Unit = "Celcius"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Väder",
                            Unit = "Väder"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Groda",
                            Unit = "Djur"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Vildsvin",
                            Unit = "Djur"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Ripa",
                            Unit = "Päls"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Fjällräv",
                            Unit = "Päls"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Träd",
                            Unit = "Annat"
                        },
                        new
                        {
                            Id = 9,
                            Type = "Hare",
                            Unit = "Päls"
                        },
                        new
                        {
                            Id = 10,
                            Unit = "Annat"
                        });
                });

            modelBuilder.Entity("Klimatkollen.Models.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("MainCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Miljö"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Djur"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Annat"
                        });
                });

            modelBuilder.Entity("Klimatkollen.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value");

                    b.Property<int>("observationId");

                    b.Property<int>("thirdCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("observationId");

                    b.HasIndex("thirdCategoryId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Klimatkollen.Models.Observation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<int>("PersonId");

                    b.Property<int>("maincategoryId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("maincategoryId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("Klimatkollen.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdentityId");

                    b.Property<string>("Lastname");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Klimatkollen.Models.ThirdCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.Property<string>("Unit");

                    b.Property<int>("categoryId");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("ThirdCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Vinterpäls",
                            Unit = "Päls",
                            categoryId = 6
                        },
                        new
                        {
                            Id = 2,
                            Type = "Sommarpäls",
                            Unit = "Päls",
                            categoryId = 6
                        },
                        new
                        {
                            Id = 3,
                            Type = "Vinterpäls",
                            Unit = "Päls",
                            categoryId = 7
                        },
                        new
                        {
                            Id = 4,
                            Type = "Sommarpäls",
                            Unit = "Päls",
                            categoryId = 7
                        },
                        new
                        {
                            Id = 5,
                            Type = "Vinterpäls",
                            Unit = "Päls",
                            categoryId = 9
                        },
                        new
                        {
                            Id = 6,
                            Type = "Sommarpäls",
                            Unit = "Päls",
                            categoryId = 9
                        },
                        new
                        {
                            Id = 7,
                            Type = "Vattentemperatur",
                            Unit = "Celcius",
                            categoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            Type = "Lufttemperatur",
                            Unit = "Celcius",
                            categoryId = 2
                        },
                        new
                        {
                            Id = 9,
                            Type = "Vindhastighet",
                            Unit = "m/s",
                            categoryId = 1
                        },
                        new
                        {
                            Id = 10,
                            Type = "Vindriktning",
                            Unit = "grader",
                            categoryId = 1
                        },
                        new
                        {
                            Id = 11,
                            Type = "PH-värde",
                            Unit = "p/h",
                            categoryId = 3
                        },
                        new
                        {
                            Id = 12,
                            Type = "Luftfuktighet",
                            Unit = "%",
                            categoryId = 3
                        },
                        new
                        {
                            Id = 13,
                            Type = "Snödjup",
                            Unit = "cm",
                            categoryId = 3
                        },
                        new
                        {
                            Id = 14,
                            Type = "Barmark",
                            Unit = "Miljö",
                            categoryId = 6
                        },
                        new
                        {
                            Id = 15,
                            Type = "Snö",
                            Unit = "Miljö",
                            categoryId = 6
                        },
                        new
                        {
                            Id = 16,
                            Type = "Barmark",
                            Unit = "Miljö",
                            categoryId = 7
                        },
                        new
                        {
                            Id = 17,
                            Type = "Snö",
                            Unit = "Miljö",
                            categoryId = 7
                        },
                        new
                        {
                            Id = 18,
                            Type = "Barmark",
                            Unit = "Miljö",
                            categoryId = 9
                        },
                        new
                        {
                            Id = 19,
                            Type = "Snö",
                            Unit = "Miljö",
                            categoryId = 9
                        });
                });

            modelBuilder.Entity("Klimatkollen.Models.UserFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilterName");

                    b.Property<int?>("PersonId");

                    b.Property<int>("categoryId");

                    b.Property<int>("mainCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("categoryId");

                    b.HasIndex("mainCategoryId");

                    b.ToTable("UserFilters");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Klimatkollen.Models.Category", b =>
                {
                    b.HasOne("Klimatkollen.Models.MainCategory", "MainCategory")
                        .WithMany()
                        .HasForeignKey("MainCategoryId");
                });

            modelBuilder.Entity("Klimatkollen.Models.Measurement", b =>
                {
                    b.HasOne("Klimatkollen.Models.Observation", "Observation")
                        .WithMany()
                        .HasForeignKey("observationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Klimatkollen.Models.ThirdCategory", "ThirdCategory")
                        .WithMany()
                        .HasForeignKey("thirdCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Klimatkollen.Models.Observation", b =>
                {
                    b.HasOne("Klimatkollen.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Klimatkollen.Models.MainCategory", "MainCategory")
                        .WithMany()
                        .HasForeignKey("maincategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Klimatkollen.Models.ThirdCategory", b =>
                {
                    b.HasOne("Klimatkollen.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Klimatkollen.Models.UserFilter", b =>
                {
                    b.HasOne("Klimatkollen.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Klimatkollen.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Klimatkollen.Models.MainCategory", "MainCategory")
                        .WithMany()
                        .HasForeignKey("mainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
