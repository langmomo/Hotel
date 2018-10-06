using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Hotels")]
    public class HotelsController : Controller
    {
        private readonly HotelsContext _context;
		static private HotelManage hm = null;

		public HotelsController(HotelsContext context)
		{
			if (_context == null)
			{
				_context = context;
			}
			if (hm == null)
			{
				hm = new HotelManage();
				_context.Hotel.AddRange(hm._hotels);
				_context.Room.AddRange(hm._rooms);
				_context.Reservations.AddRange(hm._reservations);
				_context.SaveChanges();
			}
			
		}
        // GET: api/Hotels
        [HttpGet]
        public IEnumerable<Hotel> GetHotel()
        {
            return _context.Hotel;
        }

		
		// GET: api/Hotels/5
		[HttpGet("{id}")]
        public IActionResult GetHotel([FromRoute] int id, [FromQuery] string sDate, [FromQuery] string eDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			var rooms = Room.getRooms(_context, id, sDate, eDate, null);
			List<int> allType = new List<int>();
			rooms.ForEach(_ => allType.Add(_.RoomType));
			var hotels =  _context.Hotel.Where(_ => allType.Contains(_.ID)).ToList();
			if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

   

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        [HttpPost]
        public async Task<IActionResult> PostHotel([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Capacity }, hotel);
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Capacity == id);
        }
    }
}