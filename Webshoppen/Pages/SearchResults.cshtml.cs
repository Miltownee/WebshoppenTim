using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchResultsModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string SearchWord { get; set; }

        public List<SearchItem> SearchItems { get; set; }

        public class SearchItem
        {
            public int Id { get; set; }

            public string Country { get; set; }

            public string County { get; set; }

            public int Acres { get; set; }

            public decimal Price { get; set; }


            public string Img { get; set; }
        }
        public void OnGet(string query)
        {
            SearchItems = new List<SearchItem>();
            SearchItems = _dbContext.Products.Where
                (r => r.Country.Contains(query) || r.County.Contains(query)).Select(p => new SearchItem
            {
                Id = p.Id,
                Country = p.Country,
                County = p.County,
                Acres = p.Acres,
                Price = p.Price,
                Img = p.Img
            }).ToList();
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in _dbContext.Products
                select s;
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Country);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.County);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Price);
                    break;
                default:
                    students = students.OrderBy(s => s.Acres);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());
        }
    }
}
