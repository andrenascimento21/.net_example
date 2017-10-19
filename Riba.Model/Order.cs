using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riba.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Display(Name ="Order date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Customer name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Unit price")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
