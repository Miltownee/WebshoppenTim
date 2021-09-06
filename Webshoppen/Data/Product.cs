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

        public decimal Price { get; set; }

        public Category KategoriKlass { get; set; }

        public string Img { get; set; }

        public SupplierTypeEnum SupplierType { get; set; }

        public enum SupplierTypeEnum
        {
            Unknown = 0,
            Premium = 1,
            Regular = 2,
        }
    }
}
