using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;

namespace LINQ_filmes
{
    internal class FilmekDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Database=13d2cs;User=root;Password=;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            }
        }
        public DbSet<Alkoto> Alkoto { get; set; }
        public DbSet<Film> Filmek { get; set; }
        public DbSet<Stab> Stab { get; set; }
    }
}
