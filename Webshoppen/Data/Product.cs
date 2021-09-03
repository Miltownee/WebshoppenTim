using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshoppen.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public int Acres { get; set; }

        public int Price { get; set; }

        public Category KategoriKlass { get; set; }

        public string Img { get; set; }
    }
}
