using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Contact
    {
        [Required(ErrorMessage = "Event is required.")]
        public int IdEvent { get; set; }
        [Required(ErrorMessage = "Contact name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact text is required.")]
        public string TextContact { get; set; }
    }
}
