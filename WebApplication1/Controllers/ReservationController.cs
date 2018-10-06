using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Reservation")]
	public class ReservationController : Controller
	{
		private readonly HotelsContext _context;

		public ReservationController(HotelsContext context)
		{
			_context = context;
		}

		public IActionResult GetReservation()
		{
			return Ok(_context.Reservations);
		}

		[HttpGet("{Name}")]
		public IActionResult GetReservation(string Name)
		{
			var r = _context.Reservations.Where(_ => _.CustomerName == Name).ToList();
			return Ok(r[0]);
		}

		// POST: api/Reservation
		[HttpPost("{Name}")]
		public async Task<IActionResult> PostRoom([FromRoute]string Name, [FromBody] Reservation r)
		{
			int ReservationNum = _context.Reservations.Count() + 1;
			r.ReservationNum = ReservationNum;
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var hotel = _context.Hotel.Where(_ => _.Name == Name).ToList();
			r.RoomType = hotel[0].ID;
			
			var rooms = Room.getRooms(_context, hotel[0].Capacity, r.CheckinDate, r.CheckoutDate, new List<int> { r.RoomType });
			if (rooms.Count < 1)
			{
				return Content("No Available");
			}
			else
			{
				r.RoomNum = rooms[0].RoomNum;
			}
			_context.Reservations.Add(r);
			await _context.SaveChangesAsync();
			return Ok(r);
			//return CreatedAtAction("GetReservation", new { id = ReservationNum});
		}
	}
}