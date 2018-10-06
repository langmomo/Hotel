using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
	public class Hotel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Capacity { get; set; }
		public int RoomCount { get; set; }
		public string Describe { get; set; }
		public string Pic { get; set; }
		public string Price { get; set; }
	}
}
