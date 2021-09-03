using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public CategoryModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public class ProductItem
        {
            public int Id { get; set; }

            public string Country { get; set; }

            public string County { get; set; }

            public int Acres { get; set; }

            public int Price { get; set; }

            public Category KategoriKlass { get; set; }

            public string Img { get; set; }
        }

        public List<ProductItem> ProductItems { get; set; }

        public void OnGet(int id)
        {

        }
    }
}
