using System.Threading.Tasks;

namespace Cukrászda
{
	internal class Bakery
	{
		public string Name
		{
			get;
			set;
		}
		public string Type
		{
			get;
			set;
		}
		public bool Awarded
		{
			get;
			set;
		}
		public int Price
		{
			get;
			set;
		}
		public string Unit
		{
			get;
			set;
		}
		public Bakery(string name, string type, bool awarded, int price, string unit)
		{
			Name=name;
			Type=type;
			Awarded=awarded;
			Price=price;
			Unit=unit;
		}
		public override string ToString()
		{
			return $"{Name}, {Type}, {Awarded}, {Price}Ft, {Unit}";
		}
	}
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Bakery> cakes = [];
			foreach(var file in File.ReadAllLines("cuki.txt"))
			{
				string[] line = file.Split(";");
				cakes.Add(new Bakery(line[0], line[1], bool.Parse(line[2]), int.Parse(line[3]), line[4]));
			}
			Random rnd = new();
			int rand = rnd.Next(0, cakes.Count+1);
			for (int i = 0; i < cakes.Count;i++)
			{
				if(i == rand)
				{
					Console.WriteLine(cakes[i]);
				}
			}
			int[] slices = [8,12,16,24];
			int huf = 0;
			int total = 0;
			foreach(var cake in cakes)
			{
				if(cake.Type == "vegyes")
				{
					if(cake.Unit == $"{slices[0]} szeletes")
					{
						huf = cake.Price/slices[0];
						total += huf;
					}
					else if(cake.Unit == $"{slices[1]} szeletes")
					{
						huf = cake.Price/slices[1];
						total += huf;
					}
					else if(cake.Unit == $"{slices[2]} szeletes")
					{
						huf = cake.Price/slices[2];
						total += huf;
					}
					else if(cake.Unit == $"{slices[3]} szeletes")
					{
						huf = cake.Price/slices[3];
						total += huf;
					}
					else
					{
						huf = cake.Price;
					}
					total += huf;
				}
			}
			int db = 0;
			for(int i = 0; i < cakes.Count;i++)
			{
				if(cakes[i].Awarded == true)
				{
					db++;
				}
			}
			Console.WriteLine($"Összeg: {total}");
			Console.WriteLine(db);
			Console.Write("Keresés: ");
			string user = Console.ReadLine();
			bool found = false;
			int index = 0;
			while(!found && index < cakes.Count)
			{
				if(cakes[index].Type == user)
				{
					Console.WriteLine(cakes[index].Name);
					break;
				}
				else
				{
					index++;
				}
			}
			Console.ReadKey();
        }
    }
}
