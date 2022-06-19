using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test_MVC.Data;
using System;
using System.Linq;

namespace Test_MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CampDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CampDbContext>>()))
            {
                if (context.Camera.Any())
                {
                    return;   
                }

                context.Camera.AddRange(
                    new Camera
                    {
                        Company = "Sony",
                        Model = "SEI1827"
                    },

                    new Camera
                    {
                        Company = "Canon",
                        Model = "SEI1827"
                    },

                    new Camera
                    {
                        Company = "Canon",
                        Model = "BOE18822"
                    }
                );
                context.SaveChanges();



                if (context.Operator.Any())
                {
                    return;   // DB has been seeded
                }

                context.Operator.AddRange(
                    new Operator
                    {
                        Name = "Kamil",
                        Surname = "Kowalski",
                        ContactDetails = "k.kowalski@wp.pl"
                    },
                    new Operator
                    {
                        Name = "Antoni",
                        Surname = "Browarski",
                        ContactDetails = "a.browarski@wp.pl"
                    },
                    new Operator
                    {
                        Name = "Milena",
                        Surname = "Kociołek",
                        ContactDetails = "674992614"
                    }
                );
                context.SaveChanges();


                if (context.Training.Any())
                {
                    return;   // DB has been seeded
                }

                context.Training.AddRange(
                    new Training
                    {
                        StartDate = DateTime.Now.AddMinutes(-120),
                        EndDate = DateTime.Now
                    }
                );
                context.SaveChanges();


                if (context.Organiser.Any())
                {
                    return;   // DB has been seeded
                }

                context.Organiser.AddRange(
                    new Organiser
                    {
                        Name = "Karol",
                        Surname = "Niecikowski",
                        ContactDetails = "karol.niecik@fpdc.com",
                        WorkSector = Sector.Founder
                    },
                    new Organiser
                    {
                        Name = "Aleksandra",
                        Surname = "Niecikowska",
                        ContactDetails = "a.niecik@fpdc.com",
                        WorkSector = Sector.Administration
                    }
                );
                context.SaveChanges();

                if (context.Shop.Any())
                {
                    return;   // DB has been seeded
                }

                context.Shop.AddRange(
                    new Shop
                    {
                        Name = "Adidas",
                        Description = "Sklep sportowy"
                    },
                    new Shop
                    {
                        Name = "Green Cafe Nero",
                        Description = "Kawiarnia"
                    }
                );
                context.SaveChanges();

                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "PRIMEBLUE SST TRACK PANTS",
                        Price = 139.99,
                        Shop = context.Shop.Where(s => s.Name == "Adidas").First(),
                        PhotoURL = "assets/img/product/PRIMEBLUE-SST-TRACK-PANTS.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}