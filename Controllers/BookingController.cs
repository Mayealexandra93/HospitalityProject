using Microsoft.AspNetCore.Mvc;
using HospitalityProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalityProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelDbContext _context;

        public BookingController(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }

        public IActionResult Create(DateTime? checkInDate, DateTime? checkOutDate)
        {
            var booking = new Booking
            {
                CustomerName = "Default Name",
                Email = "default@example.com"
            }; 

            if (checkInDate.HasValue)
                booking.CheckInDate = checkInDate.Value;

            if (checkOutDate.HasValue)
                booking.CheckOutDate = checkOutDate.Value;

            var rooms = _context.Rooms.ToList();
            ViewBag.Rooms = rooms;
            return View();
        }

            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // If model invalid, reload rooms to redisplay form correctly
            ViewBag.Rooms = _context.Rooms.ToList();
            return View(booking);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (id != booking.BookingId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Room) // if you have a navigation property
                .FirstOrDefaultAsync(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
