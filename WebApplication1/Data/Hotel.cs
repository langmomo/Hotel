using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Models
{
    public class Hotel
    {
		[Key]
		public string Name { get; set; }
		public int ID { get; set; }
		public int Capacity { get; set; }
		public string Describe { get; set; }
		public string Pic { get; set; }
		public int Price { get; set; }
		public int RoomCount { get; set; }
		//public List<Room> Rooms { get; set; }
		public Dictionary<DateTime, List<Room>> Reservation;
		public Boolean getAvailableRoom(int type)
		{

			return true;
		}
		
	}
}
