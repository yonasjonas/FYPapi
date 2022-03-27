using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/bookings")]
    public class BookingsController : BaseController
    {
        public readonly DataContext _context;

        public BookingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingsModel>>> GetBookingServices()
        {
            return await _context.Booking.ToListAsync();
        }

        [HttpGet("business/{businessId}")]
        public async Task<ActionResult<IEnumerable<BookingsModel>>> GetBookingServices(int businessId)
        {
            return await _context.Booking.Where(x => x.BusinessId == businessId).ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsModel>> GetBookingService(int id)
        {
            var bookingService = await _context.Booking.FindAsync(id);

            if (bookingService == null)
            {
                return NotFound();
            }

            return bookingService;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingsModel bookingService)
        {
            bookingService.id = id;
            _context.Entry(bookingService).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Booking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingsModel>> PostBooking(BookingsModel bookingService)
        {
            _context.Booking.Add(bookingService);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBooking", new { id = bookingService.id }, bookingService);
            return Ok("My message");
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingsModel>> DeleteBookingService(int id)
        {
            var bookingService = await _context.Booking.FindAsync(id);
            if (bookingService == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(bookingService);
            await _context.SaveChangesAsync();

            return bookingService;
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.id == id);
        }
    }
}

