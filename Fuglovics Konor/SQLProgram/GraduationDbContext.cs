using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProgram
{
	internal class GraduationDbContext : DbContext
	{
		public GraduationDbContext()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(!optionsBuilder.IsConfigured)
			{
				var connstring = "Server=localhost;Database=érettségi;User=root;Password=;";
				optionsBuilder.UseMySql(connstring,ServerVersion.AutoDetect(connstring));
			}
		}
		public DbSet<Teachers> Tanár
		{
			get;
			set;
		}
		public DbSet<Exams> Vizsgák
		{
			get;
			set;
		}
		public DbSet<Students> Vizsgázó
		{
			get;
			set;
		}
	}
}
