using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Events
{
    public class Event : BaseDTO
    {
        [Required(ErrorMessage = "Event name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Event slogan is required.")]
        public string Slogan { get; set; }
        [Required(ErrorMessage = "Event description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Event modality is required.")]
        public string Modality { get; set; }
        [Required(ErrorMessage = "Event date is required.")]
        public string EventDate { get; set; }
        [Required(ErrorMessage = "Total Tickets is required.")]
        public int TotalTickets { get; set; }
        [Required(ErrorMessage = "Event information is required.")]
        public string Information { get; set; }
        [Required(ErrorMessage = "Payment Method is required.")]
        public string PaymentMethod { get; set; }
        public int FreeTickets { get; set; }
        [Required(ErrorMessage = "OwnedBy is required.")]
        public int OwnedBy { get; set; }
        [Required(ErrorMessage = "Event state is required.")]
        public string State { get; set; }
    }
}


