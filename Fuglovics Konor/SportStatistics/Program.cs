<<<<<<< HEAD
﻿namespace SportStatistics
{
	internal class Player : IComparable<Player>
	{
		public string Name
		{
			get;
			set;
		}
		public string Post
		{
			get;
			set;
		}
		public int Goals
		{
			get;
			set;
		}
		public Player(string name, string post, int goals)
		{
			Name=name;
			Post=post;
			Goals=goals;
		}
		public int CompareTo(Player? other)
		{
			if(other.Goals.CompareTo(this.Goals)==0)
			{
				return this.Name.CompareTo(other.Name);
			}
			return other.Goals.CompareTo(this.Goals);
			//return this.Goals.CompareTo(other.Goals);
		}
		public override string ToString()
		{
			return $"Player name: {Name}, Post: {Post}, Goals: {Goals}";
		}
	}
	internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = [
				new Player("Kovács Péter", "Kapus", 0),
				new Player("Nagy László", "Védő", 2),
				new Player("Tóth Márton", "Középpályás", 5),
				new Player("Szabó Dániel", "Támadó", 7),
				new Player("Farkas Bence", "Támadó", 3),
				new Player("Puskás Ferenc", "Középpályás", 4)
			];
			Random rnd = new();
			int randomplayer = rnd.Next(1,7);
			int rand = randomplayer;
			for(int i=0; i<players.Count;i++)
			{
				if(i == rand)
				{
					players[i].Goals += 5;
				};
			}
			players.Sort();
			foreach(var player in players)
			{
				Console.WriteLine(player);
			}
			players.Remove(players[^1]);
			Console.WriteLine("\nThe list after deletion:");
			foreach (var player in players)
			{
				Console.WriteLine(player);
			}
			int max = 0;
			foreach(var goal in players)
			{
				if(goal.Goals < max)
				{
					max = goal.Goals;
				}
			}
			Console.WriteLine($"\nA legtöbb gólt szerző játékos: {players[max].Name}");
			Stack<Player> names = [];
			names.Push(new Player("Bárány Donát", "Csatár", 6));
			names.Push(new Player("Dzudzsák Balázs", "Középpályás", 2));
			names.Push(new Player("Lang Ádám", "Védő", 1));
			while(names.Count > 0)
			{
				Console.WriteLine($"The taken item was: {names.Pop}");
			}
			Console.ReadKey();
        }
    }
}
=======
﻿namespace SportStatistics
{
	internal class Player : IComparable<Player>
	{
		public string Name
		{
			get;
			set;
		}
		public string Post
		{
			get;
			set;
		}
		public int Goals
		{
			get;
			set;
		}
		public Player(string name, string post, int goals)
		{
			Name=name;
			Post=post;
			Goals=goals;
		}
		public int CompareTo(Player? other)
		{
			if(other.Goals.CompareTo(this.Goals)==0)
			{
				return this.Name.CompareTo(other.Name);
			}
			return other.Goals.CompareTo(this.Goals);
			//return this.Goals.CompareTo(other.Goals);
		}
		public override string ToString()
		{
			return $"Player name: {Name}, Post: {Post}, Goals: {Goals}";
		}
	}
	internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = [
				new Player("Kovács Péter", "Kapus", 0),
				new Player("Nagy László", "Védő", 2),
				new Player("Tóth Márton", "Középpályás", 5),
				new Player("Szabó Dániel", "Támadó", 7),
				new Player("Farkas Bence", "Támadó", 3),
				new Player("Puskás Ferenc", "Középpályás", 4)
			];
			Random rnd = new();
			int randomplayer = rnd.Next(1,7);
			int rand = randomplayer;
			for(int i=0; i<players.Count;i++)
			{
				if(i == rand)
				{
					players[i].Goals += 5;
				};
			}
			players.Sort();
			foreach(var player in players)
			{
				Console.WriteLine(player);
			}
			players.Remove(players[^1]);
			Console.WriteLine("\nThe list after deletion:");
			foreach (var player in players)
			{
				Console.WriteLine(player);
			}
			int max = 0;
			foreach(var goal in players)
			{
				if(goal.Goals < max)
				{
					max = goal.Goals;
				}
			}
			Console.WriteLine($"\nA legtöbb gólt szerző játékos: {players[max].Name}");
			Stack<Player> names = [];
			names.Push(new Player("Bárány Donát", "Csatár", 6));
			names.Push(new Player("Dzudzsák Balázs", "Középpályás", 2));
			names.Push(new Player("Lang Ádám", "Védő", 1));
			while(names.Count > 0)
			{
				Console.WriteLine($"The taken item was: {names.Pop}");
			}
			Console.ReadKey();
        }
    }
}
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
