using System.ComponentModel.DataAnnotations;

namespace _100Alapfilm
{
	internal class Authors
	{
		[Key]
		public int AuthorID {get; set;}
		public string Name {get; set;}
		public string Born {get; set;}
		public string Died {get; set;}
	}
	internal class Films
	{
		[Key] 
		public int FilmAzon{get; set;}
		public string Cim {get; set;}
		public int Ev {get; set;}
		public string Szines {get; set;}
		public string Mufaj {get; set;}
		public int Hossz {get; set;}
	}
	internal class FilmCrew
	{
		[Key]
		public int FilmID {get; set;}
		public int Job {get; set;}
		public int AuthorID {get; set;}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
			using var database = new FilmDbContext();
			var query = from a in database.Filmek
						where a.Szines == "színes"
						select new
						{
							a.Cim,
							a.Szines
						};
			var query2 = from b in database.Filmek
						 where b.Hossz > 120
						 orderby b.Hossz descending
						select new
						 {
							 b.Cim,
							 b.Hossz
						 };
			Console.WriteLine(string.Join("\n", query));
			Console.ReadKey();
        }
    }
}
