using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditProductModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public int Acres { get; set; }

        public decimal Price { get; set; }

        public Category KategoriKlass { get; set; }

        public string Img { get; set; }

        public void OnGet(int id)
        {
            var p = _dbContext.Products.First(p => p.Id == id);
            Country = p.Country;
            County = p.County;
            Price = p.Price;
            Acres = p.Acres;
            Img = p.Img;
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.First(p => p.Id == id);
                product.Country = Country;
                product.County = County;
                product.Acres = Acres;
                product.Price = Price;
                product.Img = Img;

                var theCat = _dbContext.Categories.First(c => c.Id == id);
                theCat.Produkter.Add(product);

                _dbContext.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
