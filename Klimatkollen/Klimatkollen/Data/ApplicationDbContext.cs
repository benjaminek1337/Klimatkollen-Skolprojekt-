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

            Category windStrength;
            Category windCategory;
            Category windDirection;


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

            modelBuilder.Entity<Category>().HasData(

                //windCategory = new Category()
                //{
                //    Id = 1,
                //    Type = "Vind",
                //},
                windStrength = new Category()
                {
                    Id = 2,
                    Type = "VindStyrka",
                    Unit = "m/s",
                        //Categories = windCategory
                    },
                windDirection = new Category()
                {
                    Id = 3,
                    Type = "Vindriktning",
                    Unit = "grader",
                        //Categories = windCategory
                    });



            modelBuilder.Entity<Measurement>().HasData(

                new Measurement()
                {
                    Id = 1,
                    Value = "14",
                    //Category = windStrength
                    },
                new Measurement()
                {
                    Id = 2,
                    Value = "134",
                    //Category = windDirection
                    });

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

            modelBuilder.Entity<Person>().HasData(

               new Person()
               {
                   Id = 1,
                   Email = "Uia@gmail.com"
               },
               new Person()
               {
                   Id = 2,
                   Email = "Udalliaa@gmail.com"

               },
               new Person()
               {
                   Id = 3,
                   Email = "Lisantia@gmail.com",
               });
        }
    }
}
