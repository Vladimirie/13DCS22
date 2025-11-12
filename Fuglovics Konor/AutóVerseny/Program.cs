namespace AutóVerseny
{
	internal class Race
	{
		public string Team
		{
			get;
			set;
		}
		public string Racer
		{
			get;
			set;
		}
		public int Age
		{
			get;
			set;
		}
		public string Track
		{
			get;
			set;
		}
		public TimeSpan LapTime
		{
			get;
			set;
		}
		public int Lap
		{
			get;
			set;
		}
		public Race(string team, string racer, int age, string track, TimeSpan laptime, int lap)
		{
			Team = team;
			Racer = racer;
			Age = age;
			Track = track;
			LapTime = laptime;	
			Lap = lap;
		}
		public override string ToString()
		{
			return $"Csapat: {Team}\nVersenyzô: {Racer}\nKor: {Age}\nPálya: {Track}\nKöridô: {LapTime.Hours}ó {LapTime.Minutes}p {LapTime.Seconds}mp\nKör: {Lap}\n";
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Race> stats = [];
			string[] data = File.ReadAllLines("autoverseny.csv");
			foreach(var file in data.Skip(1))
			{
				string[] token = file.Split(";");
				string[] t = token[4].Split(":");
				stats.Add(new Race(token[0], token[1], int.Parse(token[2]), token[3], new TimeSpan(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2])), int.Parse(token[5])));
			}
			Console.WriteLine("3. Feladat");
			Console.WriteLine(stats.Count);
			Console.WriteLine("\n4. Feladat");
			foreach(var name in stats)
			{
				int min = 60*name.LapTime.Minutes;
				int sec = name.LapTime.Seconds;
				int num = min+sec;
				if(name.Racer == "Fürge Ferenc" && name.Track == "Gran Prix Circuit" && name.Lap == 3)
				{
					Console.WriteLine($"{num} másodperc");
				}
			}
			Console.WriteLine("5.&6. Feladat");
			Console.Write("Keresés: ");
			Search:
			{
				string query = Console.ReadLine();
				int[] mins = [];
				int[] secs = [];
				int min1 = 0;
				int min2 = 0;
				foreach (var search in stats)
				{
					mins.Append(search.LapTime.Minutes);
					secs.Append(search.LapTime.Seconds);
					if(mins.Length < 0 && secs.Length < 0)
					{
						min1 = mins[0];
						min2 = secs[0];
					}
					for (int i = 0; i < mins.Length; i++)
					{
						if (mins[i] < min1)
						{
							min1 = mins[i];
						}
					}
					for (int i = 0; i < secs.Length; i++)
					{
						if (secs[i] < min2)
						{
							min2 = secs[i];
						}
					}
					if (query == search.Racer)
					{
						Console.WriteLine($"Pálya: {search.Track}, Körido: {min1}p {min2}mp");
					}
					else
					{
						Console.WriteLine("Not found.");
						goto Search;
					}
				}
			}
			Console.ReadKey();
        }
    }
}
