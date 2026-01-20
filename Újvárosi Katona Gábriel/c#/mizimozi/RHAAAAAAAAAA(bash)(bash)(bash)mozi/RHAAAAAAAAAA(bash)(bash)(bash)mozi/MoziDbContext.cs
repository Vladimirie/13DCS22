using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHAAAAAAAAAA_bash__bash__bash_mozi
{
    internal class MoziDbContext : DbContext
    {
        public MoziDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=alapfilmek;User=root;Password=;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            }
        }
        public DbSet<Filmek> Filmek { get; set; }
        public DbSet<Alkotok> Alkotok  { get; set; }
        public DbSet<Filmstab> Filmstab { get; set; }
    }
}
