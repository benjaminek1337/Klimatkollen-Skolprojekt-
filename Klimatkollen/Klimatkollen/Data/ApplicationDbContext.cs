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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Category windStrength;
            //Category windCategory;
            //Category windDirection;


            //modelBuilder.Entity<Category>(c =>
            //{
            //    c.HasData(new Category
            //    {
            //        Id = 1,
            //        Type = "Vind",
            //    });
            //    c.OwnsOne(e => e.Categories).HasData(new
            //    {
            //        Id = 2,
            //        Type = "VindStyrka",
            //        Unit = "m/s",
            //    });
            //});
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


            //modelBuilder.Entity<Category>().HasData(

            //     new Category()
            //    {
            //        Id = 1,
            //        Type = "Vind",
            //        Unit = "m/s",
            //        //mainCategoryId = 1
            //    },
            //     new Category()
            //    {
            //        Id = 2,
            //        Type = "Temperatur",
            //        Unit = "Celcius",
            //        //mainCategoryId = 1
            //    },
            //    new Category()
            //    {
            //        Id = 3,
            //        Type = "Väder",
            //        Unit = "Väder",
            //        //mainCategoryId = 1
            //    },
            //    new Category()
            //    {
            //        Id = 4,
            //        Type = "Groda",
            //        Unit = "Djur",
            //        //mainCategoryId = 2
            //    },
            //    new Category()
            //    {
            //        Id = 5,
            //        Type = "Vildsvin",
            //        Unit = "Djur",
            //        //mainCategoryId = 2
            //    },
            //    new Category()
            //    {
            //        Id = 6,
            //        Type = "Ripa",
            //        Unit = "Päls",
            //        //mainCategoryId = 2
            //    },
            //    new Category()
            //    {
            //        Id = 7,
            //        Type = "Fjällräv",
            //        Unit = "Päls",
            //        //mainCategoryId = 2
            //    },
            //    new Category()
            //    {
            //        Id = 8,
            //        Type = "Träd",
            //        Unit = "Annat",
            //        //mainCategoryId = 3
            //    },
            //    new Category()
            //    {
            //        Id = 9,
            //        Type = "Hare",
            //        Unit = "Päls",
            //        //mainCategoryId = 2
            //    });



            //modelBuilder.Entity<Measurement>().HasData(

            //    new Measurement()
            //    {
            //        Id = 1,
            //        Value = "14",
            //        //Category = windStrength
            //        },
            //    new Measurement()
            //    {
            //        Id = 2,
            //        Value = "134",
            //        //Category = windDirection
            //        });

            

            //modelBuilder.Entity<ThirdCategory>().HasData(

            //    new ThirdCategory()
            //    {
            //        Id = 1,
            //        Unit = "Päls",
            //        Type = "Vinterpäls",
            //        //CategoryId = 6,                   
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 2,
            //        Unit = "Päls",
            //        Type = "Sommarpäls",
            //        //CategoryId = 6,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 3,
            //        Unit = "Päls",
            //        Type = "Vinterpäls",
            //        //CategoryId = 7,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 4,
            //        Unit = "Päls",
            //        Type = "Sommarpäls",
            //        //CategoryId = 7,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 5,
            //        Unit = "Päls",
            //        Type = "Vinterpäls",
            //        //CategoryId = 9,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 6,
            //        Unit = "Päls",
            //        Type = "Sommarpäls",
            //        //CategoryId = 9,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 7,
            //        Unit = "Celcius",
            //        Type = "Vattentemperatur",
            //        //CategoryId = 2,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 8,
            //        Unit = "Celcius",
            //        Type = "Lufttemperatur",
            //        //CategoryId = 2,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 9,
            //        Unit = "m/s",
            //        Type = "Vindhastighet",
            //        //CategoryId = 1,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 10,
            //        Unit = "grader",
            //        Type = "Vindriktning",
            //        //CategoryId = 1,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 11,
            //        Unit = "p/h",
            //        Type = "PH-värde",
            //        //CategoryId = 3,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 12,
            //        Unit = "%",
            //        Type = "Luftfuktighet",
            //        //CategoryId = 3,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 13,
            //        Unit = "cm",
            //        Type = "Snödjup",
            //        //CategoryId = 3,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 14,
            //        Unit = "Miljö",
            //        Type = "Barmark",
            //        //CategoryId = 6,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 15,
            //        Unit = "Miljö",
            //        Type = "Snö",
            //        //CategoryId = 6,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 16,
            //        Unit = "Miljö",
            //        Type = "Barmark",
            //        //CategoryId = 7,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 17,
            //        Unit = "Miljö",
            //        Type = "Snö",
            //        //CategoryId = 7,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 18,
            //        Unit = "Miljö",
            //        Type = "Barmark",
            //        //CategoryId = 9,
            //    },
            //    new ThirdCategory()
            //    {
            //        Id = 19,
            //        Unit = "Miljö",
            //        Type = "Snö",
            //        //CategoryId = 9,
            //    });

            modelBuilder.Entity<Person>().HasData(

               new Person()
               {
                   Id = 1,
                   Email = "person1@gmail.com",
                   FirstName = "Person1"
               },
               new Person()
               {
                   Id = 2,
                   Email = "person2@gmail.com",
                   FirstName = "Person2"
               },
               new Person()
               {
                   Id = 3,
                   Email = "person3@gmail.com",
                   FirstName = "Person3"
               });
        }
    }
}
