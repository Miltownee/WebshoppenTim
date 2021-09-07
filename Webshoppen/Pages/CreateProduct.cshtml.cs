using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    [Authorize(Roles = "Admin, Product Manager")]
    [BindProperties]
    public class CreateProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateProductModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(35)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(35)]
        public string County { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int Acres { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Range(0, 9999999999, ErrorMessage = "Range Validation")]
        public decimal Price { get; set; }

        public string Img { get; set; }

        public string CategoryId { get; set; }

        



        public List<SelectListItem> AllCategories { get; set; }
        public List<SelectListItem> GetAllCategorys()
        {
            var l = new List<SelectListItem>();
            l.Add(new SelectListItem("Woodland", "3"));
            l.Add(new SelectListItem("Highland", "2"));
            l.Add(new SelectListItem("Island", "1"));
            l.Add(new SelectListItem("Desert", "4"));
            l.Add(new SelectListItem("Panets", "5"));
            return l;
        }

        public void OnGet()
        {
            AllCategories = GetAllCategorys();

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
                
                var category = _dbContext.Categories.Single(c => c.Id == Convert.ToInt32(CategoryId));
                category.Produkter.Add(s);
                _dbContext.Products.Add(s);
                _dbContext.SaveChanges();
                return RedirectToPage("/Index");

            }

            return Page();
        }
    }
}
