using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class HotelManage
    {
		public Hotel Hotel { get; set; }
		public Order Order { get; set; }
		public Customer Customer { get; set; }
		public int ID { get; set; }
		public string status { get; set; } = "Welcome!";
		public static List<Hotel> selectHotel { get; set; } = new List<Hotel>();
        public static Customer curCus = new Customer();
		// if List<Room>.length == RoomCount No available room, otherwise show this Room Type
		public Dictionary<DateTime, List<Order>> Reservation;
		public Boolean getAvailableRoom(DateTime startDate, DateTime endDate)
		{

			if (this.Reservation.ContainsKey(startDate) && this.Reservation[startDate].Count == this.Hotel.RoomCount)
			{
				return false;
			}
			if (this.Reservation.ContainsKey(endDate) && this.Reservation[endDate].Count == this.Hotel.RoomCount)
			{
				return false;
			}
			return true;

		}

		public void getAllDate(DateTime startDate, DateTime endDate)
		{
			var DateList = this.Reservation.Where(_ => DateTime.Compare(_.Key, startDate) >= 0 && DateTime.Compare(_.Key, endDate) <= 0);

		}
	}
}
