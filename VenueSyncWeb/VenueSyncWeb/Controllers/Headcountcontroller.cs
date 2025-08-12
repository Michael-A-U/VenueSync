using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenueSyncWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VenueSyncWeb.Controllers
{
    public class HeadcountController : Controller
    {
        private readonly VenueSyncDbContext _context;

        public HeadcountController(VenueSyncDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.VenueID = new SelectList(_context.Venues, "VenueID", "VenueName", null, "VenueType");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Headcount headcount)
        {
            if (ModelState.IsValid)
            {
                headcount.UserID = 1; // Mock user ID
                headcount.Timestamp = DateTime.Now;
                _context.Add(headcount);
                _context.SaveChanges();
                TempData["Message"] = "Headcount recorded successfully.";
                return RedirectToAction(nameof(Create));
            }
            ViewBag.VenueID = new SelectList(_context.Venues, "VenueID", "VenueName", headcount.VenueID, "VenueType");
            return View(headcount);
        }
    }
}