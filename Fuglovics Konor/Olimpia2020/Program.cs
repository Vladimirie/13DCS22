namespace Olimpia2020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Olympics> stats = [];
			foreach(var file in File.ReadAllLines("Olimpia2020.csv").Skip(1))
			{
				string[] line = file.Split(",");
				stats.Add(new Olympics(line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4])));
			}
			var country = stats.Select(a => a.Country).Count();
			Console.WriteLine($"Number of countries: {country}");
			var goldmedals = stats.Where(b => b.Gold >= 10).Count();
			Console.WriteLine($"Countries with atleast 10 gold medals: {goldmedals}");
			var mostmedals = stats.Select(c => c.Total).Max();
			var mostmedalcountry = stats.Where(d => d.Total == mostmedals).FirstOrDefault();
			Console.WriteLine($"{mostmedalcountry.Country} with:\n\t{mostmedalcountry.Gold} gold,\n\t{mostmedalcountry.Silver} silver,\n\tand {mostmedalcountry.Bronze} bronze medals,\n\tin total of {mostmedalcountry.Total} medals!");
			bool found = false;
			while (!found)
			{
				bool resultfound = false;
				Console.Write("? ");
				string search = Console.ReadLine();
				var result = stats.Where(a => search == a.Country).FirstOrDefault();
				foreach (var s in stats)
				{
					if (search == s.Country)
					{
						resultfound = true;
					}
				}
				if(resultfound)
				{
					Console.WriteLine($"Search results:\n\nName\t\tGold medals\n{result.Country}\t{result.Gold}");
					found = true;
				}
				else
				{
					Console.WriteLine($"No country found named {search}.");
				}
			}
			var statistics = stats.Where(e => e.Gold == 0 && e.Total > 0).Count();
			Console.WriteLine($"Countries without gold medals: {statistics}");
			Console.ReadKey();
        }
    }
}
