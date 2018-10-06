using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class HotelsContext : DbContext
    {
        public HotelsContext (DbContextOptions<HotelsContext> options)
            : base(options)
        {
        }
		
        public DbSet<WebApi.Models.Hotel> Hotel { get; set; }
		public DbSet<WebApi.Models.Room> Room { get; set; }
		public DbSet<WebApi.Data.Customer> Customers { get; set; }
		public DbSet<WebApi.Models.Reservation> Reservations { get; set; }
	}
}
