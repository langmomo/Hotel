using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class Customer
    {
		public String Name { get; set; }
		[Key]
		public String Email { get; set; }
		public String Phone { get; set; }
		public String Username { get; set; }
		public String Password { get; set; }
	}
}
