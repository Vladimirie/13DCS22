using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kultur
{
	internal class KulturDbContext : DbContext
	{
		public KulturDbContext()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connstring = "Server=localhost;Database=kulturtortenet;User=root;Password=;";
				optionsBuilder.UseMySql(connstring, ServerVersion.AutoDetect(connstring));
			}
		}
		public DbSet<Test> Feladatsor
		{
			get; 
			set;
		}
		public DbSet<Assignment> Feladat
		{
			get; 
			set;
		}
		public DbSet<Solution> Megoldas
		{
			get; 
			set;
		}
		public DbSet<Team> Csapat
		{
			get; 
			set;
		}
	}
}
