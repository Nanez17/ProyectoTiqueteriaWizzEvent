using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Image:BaseDTO
    {
        [Required(ErrorMessage = "Event is required.")]
        public int IdEvent { get; set; }
        [Required(ErrorMessage = "Image url is required.")]
        public string URL { get; set; }
    }
}
