using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ShoppingCart : BaseDTO
    {
        [Required(ErrorMessage = "Id user is required.")]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Total price is required.")]
        public decimal TotalPrice { get; set; }
    }
}
