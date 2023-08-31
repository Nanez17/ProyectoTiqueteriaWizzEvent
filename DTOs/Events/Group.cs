using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Group : BaseDTO
    {
        [Required(ErrorMessage = "Group name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Group state is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Final date is required.")]
        public DateTime FinalDate { get; set; }
    }
}
