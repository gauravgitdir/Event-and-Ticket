using Event_and_Ticket.Models;
using Microsoft.EntityFrameworkCore;
//Author: Firaol Baneta
//Date : 12/05/2023
namespace Event_and_Ticket.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() { }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Ticket>? Tickets { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Venue>? Venues { get; set; }
        public DbSet<User>? Users { get; set; }
        public object? Categories { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    TicketId = 1,
                    EventId = 1,
                    TicketType = "SampleType1",
                    Price = 10.0m,
                    QuantityAvailable = 100
                },
                new Ticket
                {
                    TicketId = 2,
                    EventId = 2,
                    TicketType = "SampleType2",
                    Price = 15.0m,
                    QuantityAvailable = 150
                }
               
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Name = "Event 1",
                    Date = DateTime.Now.AddDays(7),
                    Location = "Location 1",
                    Description = "Description 1"
                    
                },
                new Event
                {
                    EventId = 2,
                    Name = "Event 2",
                    Date = DateTime.Now.AddDays(14),
                    Location = "Location 2",
                    Description = "Description 2"
                   
                }
                
            );

            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    VenueId = 1,
                    Name = "Venue 1",
                    Address = "Address 1",
                    Capacity = 200
                    
                },
                new Venue
                {
                    VenueId = 2,
                    Name = "Venue 2",
                    Address = "Address 2",
                    Capacity = 300
                    
                }
                
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "User1"
                   
                },
                new User
                {
                    UserId = 2,
                    UserName = "User2"
                   
                }
                
            );
        }
    }
}
