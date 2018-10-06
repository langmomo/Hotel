using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Customer")]
	public class CustomerController : Controller
	{
		private readonly HotelsContext _context;

		public CustomerController(HotelsContext context)
		{
			_context = context;
		}
		[HttpGet("{name}")]
		public IActionResult GetCustomer([FromRoute]String name)
		{
			var cus = _context.Customers.Where(_ => _.Name == name).ToList();
			if (cus.Count == 0)
			{
				return NotFound();
			}
			return Ok(cus[0]);
		}
		[HttpPost]
		public async Task<IActionResult> PostCustomer([FromBody]String cus)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Content("AAA");
			//var customer = _context.Customers.Where(_ => _.Email == cus.Email || _.Name == cus.Name).ToList();
			//if (customer.Count == 0)
			//{
			//	_context.Customers.Add(cus);
			//	await _context.SaveChangesAsync();
			//	return Ok(cus);
			//}
			//else
			//{
			//	return Content("Already Register!!!");
			//}
			
		}
	}
}