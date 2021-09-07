using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webshoppen.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        []
        public string Country { get; set; }

        public string County { get; set; }

        public int Acres { get; set; }


        [Range(0, 9999999999, ErrorMessage = "Range Validation")]
        public decimal Price { get; set; }

        public string Img { get; set; }

        
    }
}
