<<<<<<< HEAD
﻿namespace Galaxis
{
	internal class Colony
	{
		public string ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Sector
		{
			get;
			set;
		}
		public Colony(string id, string name, string sector)
		{
			ID = id;
			Name = name;
			Sector = sector;
		}
		public override string ToString()
		{
			return $"ID: {ID}, Name: {Name}, Sector: {Sector}";
		}
	}
	internal class Delivery
	{
		public Colony Source
		{
			get;
			set;
		}
		public Colony Target
		{
			get;
			set;
		}
		public int Amount
		{
			get;
			set;
		}
		public Delivery(Colony source, Colony target, int amount)
		{
			Source = source;
			Target = target;
			Amount = amount;
		}
		public override string ToString()
		{
			return $"Delivery from {Source.Name} to {Target.Name} with an amount of {Amount} tonne";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Colony> colony = [];
			List<Delivery> delivery = [];
			string file1 = "kolonia.csv";
			string file2 = "szallitasok.csv";
			foreach(var data1 in File.ReadAllLines(file1))
			{
				string[] line = data1.Split(";");
				Colony col = new Colony(line[0],line[1],line[2]);
				colony[line[0]] = col;
            }
			foreach(var data2 in File.ReadAllLines(file2))
			{
				string[] line = data2.Split(";");
				Delivery dlvr = new Delivery(colony[line[0]], colony[line[1]], int.Parse(line[2]));
				delivery.Add(dlvr);
			}
            Console.WriteLine(string.Join("\n", colony));
            Console.WriteLine("");
            Console.WriteLine(string.Join("\n",delivery));
			Dictionary<Colony,int> contribution = [];
			foreach(var d in delivery)
			{
				if(!contribution.ContainsKey(d.Source))
				{
					contribution[d.Source]=0;
				}
				if(!contribution.ContainsKey(d.Target))
				{
					contribution[d.Target]=0;
				}
				contribution[d.Source]++;
				contribution[d.Target]++;
			}
            Console.WriteLine("");
            Console.WriteLine(string.Join("\n", contribution));
            Console.ReadKey();
		}
	}
}
=======
﻿namespace Galaxis
{
	internal class Colony
	{
		public string ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Sector
		{
			get;
			set;
		}
		public Colony(string id, string name, string sector)
		{
			ID = id;
			Name = name;
			Sector = sector;
		}
		public override string ToString()
		{
			return $"ID: {ID}, Name: {Name}, Sector: {Sector}";
		}
	}
	internal class Delivery
	{
		public Colony Source
		{
			get;
			set;
		}
		public Colony Target
		{
			get;
			set;
		}
		public int Amount
		{
			get;
			set;
		}
		public Delivery(Colony source, Colony target, int amount)
		{
			Source = source;
			Target = target;
			Amount = amount;
		}
		public override string ToString()
		{
			return $"Delivery from {Source.Name} to {Target.Name} with an amount of {Amount} tonne";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Colony> colony = [];
			List<Delivery> delivery = [];
			string file1 = "kolonia.csv";
			string file2 = "szallitasok.csv";
			foreach(var data1 in File.ReadAllLines(file1))
			{
				string[] line = data1.Split(";");
				Colony col = new Colony(line[0],line[1],line[2]);
				colony[line[0]] = col;
            }
			foreach(var data2 in File.ReadAllLines(file2))
			{
				string[] line = data2.Split(";");
				Delivery dlvr = new Delivery(colony[line[0]], colony[line[1]], int.Parse(line[2]));
				delivery.Add(dlvr);
			}
            Console.WriteLine(string.Join("\n", colony));
            Console.WriteLine("");
            Console.WriteLine(string.Join("\n",delivery));
			Dictionary<Colony,int> contribution = [];
			foreach(var d in delivery)
			{
				if(!contribution.ContainsKey(d.Source))
				{
					contribution[d.Source]=0;
				}
				if(!contribution.ContainsKey(d.Target))
				{
					contribution[d.Target]=0;
				}
				contribution[d.Source]++;
				contribution[d.Target]++;
			}
            Console.WriteLine("");
            Console.WriteLine(string.Join("\n", contribution));
            Console.ReadKey();
		}
	}
}
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
