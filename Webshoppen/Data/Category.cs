using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshoppen.Data
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Product> Produkter { get; set; } = new List<Product>();

    }
}
