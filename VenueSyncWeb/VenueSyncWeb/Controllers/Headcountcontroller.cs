using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VenueSyncWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VenueSyncWeb.Controllers
{
    public class HeadcountController : Controller
    {
        private readonly VenueSyncDbContext _context;

        // Inject DbContext to access the database
        public HeadcountController(VenueSyncDbContext context)
        {
            _context = context;
        }

        // GET: /Headcount/Create (shows the form)
        public IActionResult Create()
        {
            // Populate venue dropdown with VenueID and VenueName
            ViewBag.VenueID = new SelectList(_context.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: /Headcount/Create (handles form submission)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Headcount headcount)
        {
            if (ModelState.IsValid) // Check if input meets validation rules
            {
                headcount.UserID = 1; // Mock user ID (Azure AD later)
                headcount.Timestamp = DateTime.Now; // Set current time
                _context.Add(headcount); // Add to Headcounts table
                _context.SaveChanges(); // Save to database
                TempData["Message"] = "Headcount recorded successfully.";
                return RedirectToAction(nameof(Create)); // Reload form
            }
            // If validation fails, reload form with errors
            ViewBag.VenueID = new SelectList(_context.Venues, "VenueID", "VenueName", headcount.VenueID);
            return View(headcount);
        }
    }
}