using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    public class CreateProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateProductModel(ApplicationDbContext dbContext)
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

        [BindProperty]
        [Required]
        public string SelectedSupplierType { get; set; }
        public List<SelectListItem> AllSupplierTypes { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var s = new Product();

                s.Country = Country;
                s.County = County;
                s.Price = Price;
                s.Acres = Acres;
                s.Img = Img;
                s.KategoriKlass = KategoriKlass; // Oklart hur vi gör än
                s.SupplierType = Enum.Parse<Product.SupplierTypeEnum>(SelectedSupplierType);

                _dbContext.Products.Add(s);
                _dbContext.SaveChanges();
                return RedirectToPage("/Index");

            }

            return Page();
        }
    }
}
