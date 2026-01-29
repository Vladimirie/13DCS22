using Kulturforras;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulturforras
{
    internal class KulturforrasDbContext : DbContext
    {
        public KulturforrasDbContext()
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
        public DbSet<Megoldas> Megoldas { get; set; }
        public DbSet<FeladatSor> FeladatSor { get; set; }
    }
}
