using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Sector : BaseDTO
    {
        [Required(ErrorMessage = "Scenery is required.")]
        public int IdScenery { get; set; }
        [Required(ErrorMessage = "Sector name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sector price is required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Sector state is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Seats number is required.")]
        public int SeatsNumber { get; set; }
    }
}
