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

        [Required(ErrorMessage = "Field is required")]
        [MaxLength(35)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(35)]

        public string County { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int Acres { get; set; }


        [Range(0, 9999999999, ErrorMessage = "Range Validation")]
        [Required(ErrorMessage = "Field is required")]
        public decimal Price { get; set; }

        public string Img { get; set; }

        
    }
}
