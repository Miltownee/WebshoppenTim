using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshoppen.Data;

namespace Webshoppen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public class AllCaterories
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public List<AllCaterories> CatList { get; set; }

        public void OnGet()
        {
            CatList = new List<AllCaterories>();
            foreach (var caterogy in _dbContext.Categories)
            {
                CatList.Add(new AllCaterories{Name = caterogy.Name, Id = caterogy.Id});
            }
        }
    }
}
