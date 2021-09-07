using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string SortOrder { get; set; }
        public string ReverseSortOrder { get; set; }
        public void OnGet(string query, string sortOrder, string column)
        {
            SearchWord = query;


            SearchItems = new List<SearchItem>();


            var s = _dbContext.Products.Where
                (r => r.Country.Contains(query) || r.County.Contains(query)).Select(p => new SearchItem
            {
                Id = p.Id,
                Country = p.Country,
                County = p.County,
                Acres = p.Acres,
                Price = p.Price,
                Img = p.Img
            });

            if (column != null)
            {
                
                SortOrder = sortOrder;

                if (sortOrder == "desc")
                {
                    ReverseSortOrder = "asc";
                }
                else ReverseSortOrder = "desc";

                if (sortOrder == "desc")
                {
                    if (column == "Country")
                    {
                        s = s.OrderByDescending(e => e.Country);
                    }
                    if (column == "County")
                    {
                        s = s.OrderByDescending(e => e.County);
                    }
                    if (column == "Price")
                    {
                        s = s.OrderByDescending(e => e.Price);
                    }
                    if (column == "Acres")
                    {
                        s = s.OrderByDescending(e => e.Acres);
                    }

                }
                else
                {
                    if (column == "Country")
                    {
                        s = s.OrderBy(e => e.Country);
                    }
                    if (column == "County")
                    {
                        s = s.OrderBy(e => e.County);
                    }
                    if (column == "Price")
                    {
                        s = s.OrderBy(e => e.Price);
                    }
                    if (column == "Acres")
                    {
                        s = s.OrderBy(e => e.Acres);
                    }
                }
            }

            SearchItems = s.ToList();

        }
    }
}
