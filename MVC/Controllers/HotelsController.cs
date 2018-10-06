using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVCApp;
using Newtonsoft.Json;

namespace MVC.Controllers
{
	public class HotelsController : Controller
	{

		static HttpClient client = null;
		HotelManage hm = new HotelManage();
		static HotelsController()
		{
			client = PublicProperty.GetClient();
		}


		public async Task<IActionResult> HHOtel()
		{
			HttpResponseMessage response = null;
			response = await client.GetAsync("api/hotels");
			if (response.IsSuccessStatusCode)
			{
				var item = await response.Content.ReadAsStringAsync();
				List<Hotel> hotels = null;
				try
				{

					hotels = JsonConvert.DeserializeObject<List<Hotel>>(item);

				}
				catch
				{
					hotels = new List<Hotel>();
					hotels.Add(JsonConvert.DeserializeObject<Hotel>(item));

				}
				HotelManage.selectHotel = hotels;
				
				//ViewBag.Hotels = hotels;
				return View(hm);
			}
			else
			{
				return Content("Not Found");
			}
		}
		[HttpPost]
		public async Task<IActionResult> HHOtel(HotelManage hm)
		{
			int id = 0;
			if (hm != null)
			{
				id = hm.Hotel.Capacity;
			}
			string startDate = hm.Order.CheckinDate;
			string endDate = hm.Order.CheckoutDate;
			HttpResponseMessage response = null;
			if (id == 0)
			{
				response = await client.GetAsync("api/hotels");
			}
			else
			{
				response = await client.GetAsync("api/hotels/" + id + "?sDate=" + startDate + "&eDate=" + endDate);
			}

			if (response.IsSuccessStatusCode)
			{
				var item = await response.Content.ReadAsStringAsync();
				List<Hotel> hotels = null;
				try
				{

					hotels = JsonConvert.DeserializeObject<List<Hotel>>(item);

				}
				catch
				{
					hotels = new List<Hotel>();
					hotels.Add(JsonConvert.DeserializeObject<Hotel>(item));

				}
				HotelManage.selectHotel = hotels;
				//ViewBag.Hotels = hotels;
				return View(hm);
			}
			else
			{
				return Content("Not Found");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromForm] HotelManage hm)
		{
			HttpResponseMessage response = null;
			var output = JsonConvert.SerializeObject(hm.Customer);
			HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
			response = client.PostAsync("api/Customer", contentPost).Result;
			//HotelManage.Customer = cus;
			var item = await response.Content.ReadAsStringAsync();
			//var h = hm.selectHotel;
			HotelManage.curCus = hm.Customer;
			hm.status = "Welcome " + hm.Customer.Name;
			return View("HHOtel", hm);
			//return RedirectToRoute(new
			//{
			//	controller = "Home",
			//	action = "HHOtel",
			//});
		}

		public async Task<IActionResult> Login([FromForm] HotelManage hm)
		{
			HttpResponseMessage response = null;
			String name = hm.Customer.Name;
			response = await client.GetAsync("api/Customer/" + name);
			if (response.IsSuccessStatusCode)
			{
				var item = await response.Content.ReadAsStringAsync();


				hm.Customer = JsonConvert.DeserializeObject<Customer>(item);

				//return RedirectToRoute(new
				//{
				//	controller = "Home",
				//	action = "HHOtel",
				//});
				hm.status = "Welcome Back "+ hm.Customer.Name;
				return View("HHOtel", hm);
			}
			hm.status = "Login Failed, Not Found This Customer!!";
			return View("HHOtel", hm);
		}

		public async Task<IActionResult> SearchResult(Room r)
		{
			HttpResponseMessage response = await client.GetAsync("api/rooms/");
			List<Room> rooms = null;
			if (response.IsSuccessStatusCode)
			{
				var item = await response.Content.ReadAsStringAsync();
				rooms = JsonConvert.DeserializeObject<List<Room>>(item);
				return View(rooms);
			}
			else
			{
				return Content("Not Found");
			}
			//return View();
		}

		public IActionResult Book(string Name, HotelManage hm)
		{
			ViewData["RoomName"] = Name;
			//hm.Order.CustomerName = HotelManage.Customer.Name;
			//hm.Order.Email = HotelManage.Customer.Email;
			//ViewData["CustomerName"] = HotelManage.Customer.Name;
			//ViewData["Email"] = HotelManage.Customer.Email;
			//ViewData["Password"] = HotelManage.Customer.Password;
			hm.Customer = HotelManage.curCus;
			return View(hm);
		}

		[HttpPost]
		public async Task<IActionResult> Info([FromRoute] string Name, [FromForm]HotelManage hm)
		{
			HttpResponseMessage response = null;
			try
			{
				//response = client.PostAsJsonAsync(client.BaseAddress, company).Result;
				var output = JsonConvert.SerializeObject(hm.Order);
				HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");

				response = client.PostAsync("api/Reservation/"+Name, contentPost).Result;
			}
			catch (Exception ex)
			{
				return null;
			}
			if (response.IsSuccessStatusCode)
			{

				var item = await response.Content.ReadAsStringAsync();
				
				Order order = JsonConvert.DeserializeObject<Order>(item);
				return View(hm);
			} else {
				return Content("Not Found");
			}
			
		}
		[HttpPost]
		public async Task<IActionResult> Customer(HotelManage hm)
		{
			String Name = HotelManage.curCus.Name;
			if (Name != " ")
			{
				HttpResponseMessage response = null;
				response = await client.GetAsync("api/Reservation/" + Name);
				if (response.IsSuccessStatusCode)
				{
					var item = await response.Content.ReadAsStringAsync();
					List<Order> reservations = null;
					try
					{

						reservations = JsonConvert.DeserializeObject<List<Order>>(item);

					}
					catch
					{
						reservations = new List<Order>();
						reservations.Add(JsonConvert.DeserializeObject<Order>(item));

					}
					ViewBag.reservations = reservations;
					return View(hm);
				}
				else
				{
					return Content("Not Found");
				}
			}
			else
			{
				ViewBag.reservations = new List<Order>();
				hm.status = "Welcome! Please Login";
				return View("HHOtel", hm);
			}
			
		}

	}
}
