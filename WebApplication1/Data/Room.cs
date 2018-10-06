using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Models
{
    public class Room
    {
		[Key]
		public int RoomNum { get; set; }
		public int RoomType { get; set; }
		public Customer BookInfo { get; set; }
		public static List<Room> getRooms(HotelsContext hm, int Capacity, string sdate, string edate, List<int> idList)
		{
			if (idList == null)
			{
				var hotels = hm.Hotel.Where(_ => _.Capacity == Capacity).ToList();
				

				idList = new List<int>();
				hotels.ForEach(_ => idList.Add(_.ID));
			}
			var startDate = Convert.ToDateTime(sdate);
			var endDate = Convert.ToDateTime(edate);
			var BookedRooms = hm.Reservations.Where(_ => idList.Contains(_.RoomType) 
				&& ((DateTime.Compare(startDate, Convert.ToDateTime(_.CheckinDate) )>=0 && DateTime.Compare(startDate, Convert.ToDateTime(_.CheckoutDate)) <= 0)
				||(DateTime.Compare(endDate, Convert.ToDateTime(_.CheckinDate)) >=0 && DateTime.Compare(endDate, Convert.ToDateTime(_.CheckoutDate)) <= 0))).ToList();
			List<int> roomList = new List<int>();
			BookedRooms.ForEach(_ => roomList.Add(_.RoomNum));
			var rooms = hm.Room.Where(_ => !roomList.Contains(_.RoomNum) && idList.Contains(_.RoomType)).ToList();
			return rooms;
		}


	}
}
