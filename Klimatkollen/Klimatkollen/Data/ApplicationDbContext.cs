using System;
using System.Collections.Generic;
using System.Text;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Klimatkollen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Measurement> Measurements{ get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<MainCategory> MainCategories{ get; set; }
        public DbSet<ThirdCategory> ThirdCategories{ get; set; }
        public DbSet<UserFilter> UserFilters{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MainCategory>().HasData(

                new MainCategory()
                {
                    Id = 1,
                    CategoryName = "Miljö"
                },
                new MainCategory()
                {
                    Id = 2,
                    CategoryName = "Djur"
                },
                new MainCategory()
                {
                    Id = 3,
                    CategoryName = "Annat"
                });

            modelBuilder.Entity<Category>().HasData(

                 new Category()
                 {
                     Id = 1,
                     Type = "Vind",
                     Unit = "m/s",
                 },
                 new Category()
                 {
                     Id = 2,
                     Type = "Temperatur",
                     Unit = "Celcius",
                 },
                new Category()
                {
                    Id = 3,
                    Type = "Väder",
                    Unit = "Väder",
                },
                new Category()
                {
                    Id = 4,
                    Type = "Groda",
                    Unit = "Djur",
                },
                new Category()
                {
                    Id = 5,
                    Type = "Vildsvin",
                    Unit = "Djur",
                },
                new Category()
                {
                    Id = 6,
                    Type = "Ripa",
                    Unit = "Päls",
                },
                new Category()
                {
                    Id = 7,
                    Type = "Fjällräv",
                    Unit = "Päls",
                },
                new Category()
                {
                    Id = 8,
                    Type = "Träd",
                    Unit = "Annat",
                },
                new Category()
                {
                    Id = 9,
                    Type = "Hare",
                    Unit = "Päls",
                },
                new Category()
                {
                    Id = 10,
                    Unit = "Annat",
                }

                );

            modelBuilder.Entity<ThirdCategory>().HasData(

                new ThirdCategory()
                {
                    Id = 1,
                    Unit = "Päls",
                    Type = "Vinterpäls",
                    categoryId = 6,
                },
                new ThirdCategory()
                {
                    Id = 2,
                    Unit = "Päls",
                    Type = "Sommarpäls",
                    categoryId = 6,
                },
                new ThirdCategory()
                {
                    Id = 3,
                    Unit = "Päls",
                    Type = "Vinterpäls",
                    categoryId = 7,
                },
                new ThirdCategory()
                {
                    Id = 4,
                    Unit = "Päls",
                    Type = "Sommarpäls",
                    categoryId = 7,
                },
                new ThirdCategory()
                {
                    Id = 5,
                    Unit = "Päls",
                    Type = "Vinterpäls",
                    categoryId = 9,
                },
                new ThirdCategory()
                {
                    Id = 6,
                    Unit = "Päls",
                    Type = "Sommarpäls",
                    categoryId = 9,
                },
                new ThirdCategory()
                {
                    Id = 7,
                    Unit = "Celcius",
                    Type = "Vattentemperatur",
                    categoryId = 2,
                },
                new ThirdCategory()
                {
                    Id = 8,
                    Unit = "Celcius",
                    Type = "Lufttemperatur",
                    categoryId = 2,
                },
                new ThirdCategory()
                {
                    Id = 9,
                    Unit = "m/s",
                    Type = "Vindhastighet",
                    categoryId = 1,
                },
                new ThirdCategory()
                {
                    Id = 10,
                    Unit = "grader",
                    Type = "Vindriktning",
                    categoryId = 1,
                },
                new ThirdCategory()
                {
                    Id = 11,
                    Unit = "p/h",
                    Type = "PH-värde",
                    categoryId = 3,
                },
                new ThirdCategory()
                {
                    Id = 12,
                    Unit = "%",
                    Type = "Luftfuktighet",
                    categoryId = 3,
                },
                new ThirdCategory()
                {
                    Id = 13,
                    Unit = "cm",
                    Type = "Snödjup",
                    categoryId = 3,
                },
                new ThirdCategory()
                {
                    Id = 14,
                    Unit = "Miljö",
                    Type = "Barmark",
                    categoryId = 6,
                },
                new ThirdCategory()
                {
                    Id = 15,
                    Unit = "Miljö",
                    Type = "Snö",
                    categoryId = 6,
                },
                new ThirdCategory()
                {
                    Id = 16,
                    Unit = "Miljö",
                    Type = "Barmark",
                    categoryId = 7,
                },
                new ThirdCategory()
                {
                    Id = 17,
                    Unit = "Miljö",
                    Type = "Snö",
                    categoryId = 7,
                },
                new ThirdCategory()
                {
                    Id = 18,
                    Unit = "Miljö",
                    Type = "Barmark",
                    categoryId = 9,
                },
                new ThirdCategory()
                {
                    Id = 19,
                    Unit = "Miljö",
                    Type = "Snö",
                    categoryId = 9,
                });


        }
    }
}
