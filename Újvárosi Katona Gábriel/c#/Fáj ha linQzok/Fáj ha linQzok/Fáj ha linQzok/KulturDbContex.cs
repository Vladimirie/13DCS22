using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fáj_ha_linQzok
{
    
        internal class KulturDbContex : DbContext
        {
            public KulturDbContex()
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    var connectionString = "Server=localhost;Database=kulturtortenet;User=root;Password=;";
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                }
            }
            public DbSet<Csapat> Csapat { get; set; }
            public DbSet<Feladat> Feladat { get; set; }
            public DbSet<Feladatsor> Feladatsor { get; set; }
            public DbSet<Megoldas> Megoldas { get; set; }


        }
    }

