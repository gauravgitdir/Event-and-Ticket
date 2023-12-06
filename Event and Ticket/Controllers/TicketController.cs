using Event_and_Ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//Author:Firaol Baneta
//date: 12/01/2023
//Movie tickets
namespace Event_and_Ticket.Controllers
{
    public class TicketController : Controller
    {
        private readonly MovieContext _context;

        public TicketController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var tickets = _context.Tickets
                .Include(t => t.Event)
                .OrderBy(t => t.TicketId)
                .ToList();

            return View(tickets);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Events = _context.Events.ToList(); // Assuming Events exist in the context

            return View("AddUpdate", new Ticket());
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                TempData["UserMessage"] = $"You just added the ticket {ticket.TicketType}";

                return RedirectToAction("List");
            }

            ViewBag.Action = "Add";
            ViewBag.Events = _context.Events.ToList();
            return View("AddUpdate", ticket);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticket = _context.Tickets
                .Include(t => t.Event)
                .FirstOrDefault(t => t.TicketId == id);

            ViewBag.Action = "Update";
            ViewBag.Events = _context.Events.ToList();

            return View("AddUpdate", ticket);
        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Update(ticket);
                _context.SaveChanges();

                TempData["UserMessage"] = $"You just updated the ticket {ticket.TicketType}";

                return RedirectToAction("List");
            }

            ViewBag.Action = "Update";
            ViewBag.Events = _context.Events.ToList();
            return View("AddUpdate", ticket);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ticket = _context.Tickets.Find(id);
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Delete(int id, Ticket ticket)
        {
            var ticketToDelete = _context.Tickets.Find(id);
            _context.Tickets.Remove(ticketToDelete);
            _context.SaveChanges();

            TempData["UserMessage"] = $"You just deleted the ticket {ticketToDelete.TicketType}";

            return RedirectToAction("List");
        }
    }
}
