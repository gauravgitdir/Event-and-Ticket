using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event_and_Ticket.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        // Navigation property for Tickets
        public ICollection<Ticket> Tickets { get; set; }
    }
}
