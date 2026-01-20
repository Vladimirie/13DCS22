using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;



namespace Zulu
{
    internal class ErettsegiDbContext : DbContext
    {
        public ErettsegiDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                var connectionString = "Server=localhost;Database=erettsegi;User=root;Password=;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            
            }
        }
        public DbSet<Tanar> Tanar { get; set; }
        public DbSet<Vizsgak> Vizsgak { get; set; }
        public DbSet<Vizsgazo> Vizsgazo { get; set; }


    }
}
