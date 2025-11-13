namespace Mozi
{
    internal class Program
    {
        static void Main(string[] args)
        {
			List<Theater> films = [];
			foreach(var file in File.ReadAllLines("bemenet.csv").Skip(1))
			{
				string[] line = file.Split(";");
				films.Add(new Theater(line[0], line[1], int.Parse(line[2]), int.Parse(line[3])));
			}
			//films.Sort();
			var sorted = films
				.OrderBy(a => a.StartInSecs)
				.ThenByDescending(a => a.AudienceAge)
				.ThenBy(a => a.Name)
				.ToList();
			foreach (var film in sorted)
			{
				Console.WriteLine(film);
			}
			Console.ReadKey();
        }
    }
}
