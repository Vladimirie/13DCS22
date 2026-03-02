using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _100Alapfilm
{
	internal class FilmDbContext: DbContext
	{
		public FilmDbContext()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var connstring = "Server=localhost;Database=100alapfilm;User=root;Password=;";
				optionsBuilder.UseMySql(connstring, ServerVersion.AutoDetect(connstring));
			}
		}
		public DbSet<Authors> Alkotok
		{
			get;
			set;
		}
		public DbSet<Films> Filmek
		{
			get;
			set;
		}
		public DbSet<FilmCrew> FilmStab
		{
			get;
			set;
		}
	}
}
