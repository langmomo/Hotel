using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Models
{
    public class HotelManage
    {
		public Hotel[] _hotels { get; set; }
		public Room[] _rooms { get; set; }
		public List<Reservation> _reservations { get; set; }
		public List<Customer> _customers { get; set; }
		public HotelManage()
		{

			//var Room1 = new Room[] {
			//	new Room { RoomNum = 101, RoomType=1},
			//	new Room { RoomNum = 102, RoomType=1},
			//	new Room { RoomNum = 103, RoomType=1 },
			//};

			//var Room2 = new Room[] {
			//	new Room { RoomNum = 201, RoomType=2},
			//	new Room { RoomNum = 202, RoomType=2},
			//	new Room { RoomNum = 203, RoomType=2 },
			//};

			//var Room3 = new Room[] {
			//	new Room { RoomNum = 301, RoomType=3},
			//	new Room { RoomNum = 302, RoomType=3},
			//	new Room { RoomNum = 303, RoomType=3},
			//};
			var r301 = new Room { RoomNum = 301, RoomType = 3 };
			var r201 = new Room { RoomNum = 201, RoomType = 2 };
			_rooms = new Room[]{
				new Room { RoomNum = 101, RoomType=1},
				new Room { RoomNum = 102, RoomType=1},
				new Room { RoomNum = 103, RoomType=1 },
				r201,
				new Room { RoomNum = 202, RoomType=2},
				new Room { RoomNum = 203, RoomType=2 },
				r301,
				new Room { RoomNum = 302, RoomType=3},
				new Room { RoomNum = 303, RoomType=3},
			};


			_hotels = new Hotel[]{
				new Hotel { ID = 1, RoomCount = 3, Name = "QUEEN DELUXE ROOM", Describe = "Newly styled Queen Deluxe rooms are each outfitted with a queen-size bed, pull-out sleeper sofa, and must-have amenities like wireless and DSL internet, a microwave/refrigerator combo, and full private bath.", Capacity = 2, Pic = "http://www.midtownhotel.com/files/4206/2017JeffCutlerPhoto-MidtownHotel-5398-HDR_RoomCrop_Accessible_Rooms.jpg", Price = 300},
				new Hotel { ID = 2, RoomCount = 3, Name = "KING ROOM", Describe = "Enjoy the space in your standard king room with a king-sized bed and additional space for a pull-out sofa and sitting area. You’ll love the clean and modern feel in this room.", Pic="http://www.midtownhotel.com/files/4206/2017JeffCutlerPhoto-MidtownHotel-5365-HDR_RoomsCrop_Double_.jpg", Capacity = 1, Price = 400},
				new Hotel { ID = 3, RoomCount = 3, Name = "EXECUTIVE KING SUITE", Capacity = 1,  Pic = "http://www.midtownhotel.com/files/4206/2017JeffCutlerPhoto-MidtownHotel-5471-HDR_RoomCrop_ExecutiveKing.jpg" ,Describe="Pamper Yourself in our Queen Deluxe Room featuring One Queen Sized Bed ,37 Flat screen HD TV with cable, Sofa with Pull out Queen Sleeper ,Chair and Ottoman, In Room safe , Desk Space and a Microwave /Refrigerator Combination."}
			};

			_reservations = new List<Reservation>{
				new Reservation { ReservationNum = 1, RoomNum = 301, RoomType = 3, CheckinDate="6/10/2018", CheckoutDate="6/11/2018", Name="EXECUTIVE KING SUITE", Email="XX@gmail.com", CustomerName="LM"},
				new Reservation { ReservationNum = 2, RoomNum = 201, RoomType = 2, CheckinDate="6/10/2018", CheckoutDate="6/11/2018", Name="KING ROOM", Email="XX@gmail.com", CustomerName="LM"},
				new Reservation { ReservationNum = 3, RoomNum = 101, RoomType=1, CheckinDate="6/10/2018", CheckoutDate="6/11/2018", Name="QUEEN DELUXE ROOM", Email="XX@gmail.com", CustomerName="LM"},
			};

			_customers = new List<Customer>
			{
				new Customer { Name="LM", Email="langmomo@126.com", Phone="333-4441111"}
			};






		}

		

	}
}
