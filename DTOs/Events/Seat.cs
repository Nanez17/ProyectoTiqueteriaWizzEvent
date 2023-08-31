using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Seat : BaseDTO
    {
        [Required(ErrorMessage = "Scenery is required.")]
        public int IdScenery { get; set; }
        [Required(ErrorMessage = "Sector is required.")]
        public int IdSector { get; set; }
        [Required(ErrorMessage = "Seat name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Seat state is required.")]
        public string State { get; set; }
    }
}
