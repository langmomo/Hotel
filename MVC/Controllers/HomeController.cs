using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVCApp;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
		static HttpClient client = null;
		HotelManage hm = new HotelManage();
		static HomeController()
		{
			client = PublicProperty.GetClient();
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult HomePage()
		{
			return View();
		}
		

		public IActionResult Search(Room r)
		{
			return View(r);
		}

		
		

		public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
