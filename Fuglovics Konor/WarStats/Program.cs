namespace WarStats
{
	internal class War
	{
		public string Name { get; set; }
		public string Place { get; set; }
		public int Soldiers { get; set; }
		public int Time { get; set; }
		public War(string name, string place, int soldiers, int time)
		{
			Name=name;
			Place=place;
			Soldiers=soldiers;
			Time=time;
		}
		public override string ToString()
		{
			return $"{Name} ({Place}): {Time}";
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
			//1. Feladat
			Console.WriteLine("1.");
            List<War> stats = [];
			foreach(var file in File.ReadAllLines("feladat1.txt"))
			{
				string[] line = file.Split(";");
				stats.Add(new War(line[0], line[1], int.Parse(line[2]), int.Parse(line[3])));
			}
			var sorted = stats
				.OrderByDescending(a => a.Soldiers)
				.ThenByDescending(a => a.Time)
				.ThenBy(a => a.Name);
			foreach(var data in sorted)
			{
				Console.WriteLine(data);
			}
			//2. Feladat
			Console.WriteLine("\n2.");
			SortedDictionary<string, int> wars = [];
			foreach (var file2 in File.ReadAllLines("feladat2.txt"))
			{
				string[] line = file2.Split(";");
				string[] date = line[1].Split(":");
				string[] name = date[1].Split(",");
				foreach (var item in name)
				{
					if (wars.ContainsKey(item))
					{
						wars[item] += 1;
					}
					else
					{
						wars[item] = 0;
					}
				}
			}
			int db = 0;
			foreach(var w in wars.Keys)
			{
				if(wars[w] > 1)
				{
					Console.WriteLine($"{w}: {wars[w]}");
				}
			}
			Console.ReadKey();
        }
    }
}
