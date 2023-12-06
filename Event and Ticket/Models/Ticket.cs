using System.ComponentModel.DataAnnotations.Schema;

namespace Event_and_Ticket.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

        // Define ForeignKey attribute to represent the relationship
        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
