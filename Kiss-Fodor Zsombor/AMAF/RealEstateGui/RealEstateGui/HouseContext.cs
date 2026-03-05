using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateGui
{
    internal class HouseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=ingatlan;User=root;Password=;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            }
        }
        public DbSet<Categories> Categories { get; set; }
        //public DbSet<RealEstates> RealEstates { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
