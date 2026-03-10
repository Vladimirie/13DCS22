using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateGUI
{
	internal class RealEstateDBContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connectionString = "Server=localhost;Database=ingatlan;User=root;Password=;";
				optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			}
		}
		public DbSet<Seller> Sellers{ get; set;}
		public DbSet<RealEstate> RealEstates { get; set;}
	}
}
