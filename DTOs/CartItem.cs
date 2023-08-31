using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CartItem : BaseDTO
    {
        public string eventName { get; set; }
        public string eventDate { get; set; }
        public string sectorName { get; set; }
        public int seatId { get; set; }
        public string seatName { get; set; }
        public decimal seatPrice { get; set; }
    }
}
