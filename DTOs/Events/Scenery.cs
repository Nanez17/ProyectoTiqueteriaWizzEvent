using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Scenery : BaseDTO
    {
        public int IdEvent { get; set; }
        [Required(ErrorMessage = "Scenery name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Scenery location is required.")]
        public string Location { get; set; }

    }
}
