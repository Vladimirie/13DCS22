 namespace Videogames
{
	internal class VideoGames
	{
		public string Name
		{
			get;
			set;
		}
		public string Console
		{
			get;
			set;
		}
		public string Genre
		{
			get;
			set;
		}
		public string Publisher
		{
			get;
			set;
		}
		public string Developer
		{
			get;
			set;
		}
		public double CriticScore
		{
			get;
			set;
		}
		public double AllSoldMillions
		{
			get;
			set;
		}
		public int ReleaseYear
		{
			get;
			set;
		}
		public VideoGames(string name, string console, string genre, string pub, string dev, double criticpt, double total_sold_m, int year)
		{
			Name = name;
			Console = console;
			Genre = genre;
			Publisher = pub;
			Developer = dev;
			CriticScore = criticpt;
			AllSoldMillions = total_sold_m;
			ReleaseYear = year;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<VideoGames> database = new();
			foreach(var data in File.ReadAllLines("Video_Jatek_Eladasok.txt").Skip(1))
			{
				string[] line = data.Split("|");
				database.Add(new VideoGames(line[0], line[1], line[2], line[3], line[4], double.Parse(line[5]), double.Parse(line[6]), int.Parse(line[7])));
			}
			int total = 0;
			for(int i = 1; i <=  database.Count; i++)
			{
				total = i;
			}
			Console.WriteLine($"There are {total} games in total.");
			int critics = 0;
			foreach(var critic in database)
			{
				if(critic.CriticScore >= 9.5)
				{
					critics++;
				}
			}
			Console.WriteLine($"\nThere are {critics} games that have a critic score of 9.5 or above.");
			double maxsold = 0;
			string[] gamedata = new string[4];
			foreach(var i in database)
			{
				if(i.AllSoldMillions > maxsold)
				{
					maxsold = i.AllSoldMillions;
					gamedata[0] = i.Name;
					gamedata[1] = i.Console;
					gamedata[2] = maxsold.ToString();
					gamedata[3] = i.CriticScore.ToString();
				}
			}
			Console.WriteLine($"\nThe most sold game is: {gamedata[0]}\n\tAvailable: {gamedata[1]}\n\tMaximum sold: {gamedata[2]} million\n\tCritic Score: {gamedata[3]}");
			bool successful = false;
			Console.Write("? ");
			string a = Console.ReadLine();
			List<int> years = new();
			foreach (var i in database)
			{
				if (a == i.Publisher)
				{
					years.Add(i.ReleaseYear);
				}
			}
			//Console.WriteLine(string.Join(", ", years));
			if (years.Count != 0)
			{
				Console.WriteLine($"The first release year is: {years.Min()}");
				successful = true;
			}
			else
			{
				Console.WriteLine($"No publishers named {a}");
			}
			int genregames = 0;
			foreach (var game in database)
			{
				if (game.Genre == "Akció")
				{
					genregames++;
				}
			}
			Console.WriteLine($"\nThere are {genregames} action games.");
			Console.ReadKey();
        }
    }
}
