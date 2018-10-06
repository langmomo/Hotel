using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Order
    {
		public int ReservationNum { get; set; }
		public String CheckinDate { get; set; }
		public String CheckoutDate { get; set; }
		public String Name { get; set; }
		public String CustomerName { get; set; }
		public String Email { get; set; }
		public String Phone { get; set; }
		public int RoomType { get; set; }
		public int RoomNum { get; set; }
		public String Num { get; set; }	

	}
}
