using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    [Authorize(Roles="Admin, Product Manager")]
    [BindProperties]
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditProductModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }
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

        public void OnGet(int id)
        {
            Id = id;
            var p = _dbContext.Products.First(p => p.Id == id);
            Country = p.Country;
            County = p.County;
            Price = p.Price;
            Acres = p.Acres;
            Img = p.Img;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Index");
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

                _dbContext.SaveChanges();
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
