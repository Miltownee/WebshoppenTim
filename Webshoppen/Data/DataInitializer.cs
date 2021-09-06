using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webshoppen.Data;

namespace Webshoppen.Data
{
    public class DataInitializer
    {

        public static void SeedData(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            context.Database.Migrate();
            SeedRoles(context);
            SeedUsers(userManager);
            SeedCategory(context);
            SeedProduct(context);
        }

        private static void SeedCategory(ApplicationDbContext context)
        {
            if (!context.Categories.Any(r => r.Name == "Woodlands"))
            {
                var cat = new Category { Name = "Woodlands" };
                context.Categories.Add(cat);
            }
            if (context.Categories.Count(r => r.Name == "Highlands") == 0)
            {
                var cat = new Category { Name = "Highlands"};
                context.Categories.Add(cat);
            }
            if (context.Categories.Count(r => r.Name == "Islands") == 0)
            {
                var cat = new Category { Name = "Islands" };
                context.Categories.Add(cat);
            }
            if (context.Categories.Count(r => r.Name == "Desert") == 0)
            {
                var cat = new Category { Name = "Desert" };
                context.Categories.Add(cat);
            }
            if (context.Categories.Count(r => r.Name == "Planets") == 0)
            {
                var cat = new Category { Name = "Planets" };
                context.Categories.Add(cat);
            }


            context.SaveChanges();
        }

        private static void SeedProduct(ApplicationDbContext context)
        {
            if (context.Products.Count(p => p.Country == "Sweden") == 0)
            {
                var produkt = new Product
                {
                    Country = "Sweden",
                    County = "Boras,Tarzanberget",
                    Acres = 355,
                    Price = 12000,
                    Img = "http://4.bp.blogspot.com/-T2Pmv19cFuA/UpC57oBPUeI/AAAAAAAAAzo/zr22qYXus-Q/s1600/IMG_1391.JPG",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Woodlands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p=>p.Country == "Russia") == 0)
            {
                var produkt = new Product
                {
                    Country = "Russia",
                    County = "Pripyat, Chenobyl",
                    Acres = 75,
                    Price = 450,
                    Img = "https://cdn.theatlantic.com/media/img/photo/2016/04/still-cleaning-up-30-years-after-th/c01_492210546-1/original.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Woodlands")
                }; 
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Brazil") == 0)
            {
                var produkt = new Product
                {
                    Country = "Brazil",
                    County = "São Sebastiãno, Amazonas",
                    Acres = 800,
                    Price = 2400000,
                    Img = "http://3.bp.blogspot.com/-RCj-FgA3lno/TwLD-Xa4wlI/AAAAAAAAAHM/OAYA13nQUxY/s1600/En+magisk+resa-+AMAZONAS+REGNSKOG.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Woodlands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Norge") == 0)
            {
                var produkt = new Product
                {
                    Country = "Norge",
                    County = "Lofoten",
                    Acres = 120,
                    Price = 4457448,
                    Img = "https://cdn.tourradar.com/s3/tour/1500x800/154963_23c91715.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Highlands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Faroe Islands") == 0)
            {
                var produkt = new Product
                {
                    Country = "Faroe Islands",
                    County = "Hattarvik",
                    Acres = 18,
                    Price = 18000000,
                    Img = "https://www.bravofly.se/erbjudande/flyg/bravofly/img/faroe_islands_vagar.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Highlands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Scotland") == 0)
            {
                var produkt = new Product
                {
                    Country = "Scotland",
                    County = "Isle of mull",
                    Acres = 233,
                    Price = 7000000,
                    Img = "https://images.ctfassets.net/mivicpf5zews/3HyE8KUvz8TiLp6DEGAuqD/a36ec08b0dd0edd8bb381df62752c9b1/Scotland-Top5-Skye-1200x600.jpg?q=70",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Highlands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Solomon Islands") == 0)
            {
                var produkt = new Product
                {
                    Country = "Solomon Islands",
                    County = "Tinakula",
                    Acres = 2400,
                    Price = 650355000,
                    Img = "https://volcanodiscovery.de/uploads/pics/tinakula_lancemcc_l.jpg0",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Islands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Bahamas") == 0)
            {
                var produkt = new Product
                {
                    Country = "Bahamas",
                    County = "Fowl Cay",
                    Acres = 22,
                    Price = 2870500,
                    Img = "https://www.caribbeancastaways.com/wp-content/uploads/2020/04/Fowl-Cay-Resort-Bahamas-Exuma-Header.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Islands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Kiribati") == 0)
            {
                var produkt = new Product
                {
                    Country = "Kiribati",
                    County = "Starbuck Island",
                    Acres = 400310718,
                    Price = 400310718,
                    Img = "https://upload.wikimedia.org/wikipedia/commons/a/a1/Starbuck_ISS006-28727.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Islands")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Tchad") == 0)
            {
                var produkt = new Product
                {
                    Country = "Tchad",
                    County = "La",
                    Acres = 70,
                    Price = 300,
                    Img = "https://explore-chad.org/wp-content/uploads/2018/03/Startseite_Tschad_Norden.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Desert")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Australia") == 0)
            {
                var produkt = new Product
                {
                    Country = "Australia",
                    County = "Min min",
                    Acres = 1,
                    Price = 1,
                    Img = "https://ivebeenevery.files.wordpress.com/2009/12/grave.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Desert")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Mongolia") == 0)
            {
                var produkt = new Product
                {
                    Country = "Mongolia",
                    County = "Luus",
                    Acres = 6450,
                    Price = 740000,
                    Img = "https://www.selenatravel.com/upload/media/tour_photos/0001/01/cc2ae716c002a9ae2fca02c68bcebb8e49368bf4.jpeg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Desert")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Moon") == 0)
            {
                var produkt = new Product
                {
                    Country = "Moon",
                    County = "moon",
                    Acres = 350,
                    Price = 1200000000,
                    Img = "https://media.npr.org/assets/img/2020/10/26/water-moon-crater-nasa_wide-3343c41146d500f46e59a2c761befadd33da0e0e.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Planets")
                };
                context.Products.Add(produkt);
            }
            if (context.Products.Count(p => p.Country == "Mars") == 0)
            {
                var produkt = new Product
                {
                    Country = "Mars",
                    County = "mars",
                    Acres = 350,
                    Price = 2100000000,
                    Img = "https://images.news18.com/ibnlive/uploads/2021/08/1627902340_mars-new-images-1200x800.jpg",
                    KategoriKlass = context.Categories.First(cat => cat.Name == "Planets")
                };
                context.Products.Add(produkt);
            }

            context.SaveChanges();

        }






        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("stefan.holmberg@systementor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "stefan.holmberg@systementor.se";
                user.Email = "stefan.holmberg@systementor.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            if (userManager.FindByEmailAsync("tim.jonasson@hotmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "tim.jonasson@hotmail.com";
                user.Email = "tim.jonasson@hotmail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123!").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }


        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Admin",
                    Name = "Admin"
                });
            }
            if (!context.Roles.Any(r => r.Name == "NormalUser"))
            {
                context.Roles.Add(new IdentityRole
                {
                    NormalizedName = "NormalUser",
                    Name = "NormalUser"
                });
            }

            context.SaveChanges();
        }
    }
}
