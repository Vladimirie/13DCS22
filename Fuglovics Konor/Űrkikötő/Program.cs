namespace Űrkikötő
{
	internal class Vehicle
	{
		public string LicensePlate
		{
			get;
			set;
		}
		public string Type
		{
			get;
			set;
		}
		public int ArrivesInDays
		{
			get;
			set;
		}
		public override string ToString()
		{
			return $"Rendszám: {LicensePlate}, Típus: {Type}, Érkezés (nap): {ArrivesInDays}";
		}
		public Vehicle(string licenseplate, string type, int arrive)
		{
			LicensePlate = licenseplate;
			Type = type;
			ArrivesInDays = arrive;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> allcars = [];
			HashSet<string> alltypes = [];
			Dictionary<string, int> allstats = [];
			string[] data = File.ReadAllLines("jarmuvek.csv");
			foreach (var file in data.Skip(1))
			{
				string[] line = file.Split(";");
				allcars.Add(new Vehicle(line[0], line[1], int.Parse(line[2])));
				alltypes.Add(line[1]);
			}
			int ambulamt = 0;
			int carrieramt = 0;
			int searchamt = 0;
			int casualamt = 0;
			List<int> amount = [];
			foreach(var amt in allcars)
			{
				if (amt.Type == "Mentő")
				{
					ambulamt++;
				}
				else if (amt.Type == "Személy")
				{
					casualamt++;
				}
				else if (amt.Type == "Kutató")
				{
					searchamt++;
				}
				else if (amt.Type == "Teher")
				{
					carrieramt++;
				}
			}
			amount.Add(ambulamt);
			amount.Add(searchamt);
			amount.Add(casualamt);
			amount.Add(carrieramt);
			int i = 0;
			foreach(var tip in alltypes)
			{ 
				allstats.Add(tip, amount[i]);
				i++;
			}
			//---------------------------------------
			void Days() //1.
			{
				Dictionary<int, int> daycheck = [];
				int count = 1;
				foreach (var item in allcars)
				{
					int cars = 0;
					foreach (var day in allcars)
					{
						if (day.ArrivesInDays == count)
						{
							cars++;
						}
					}
					daycheck.Add(count, cars);
					count++;
					if(count == 31)
					{
						break;
					}
				}
				Console.WriteLine(string.Join("\n", daycheck));
				int max = 0;
				int num = 0;
				foreach(var i in daycheck.Values)
				{
					if(i > max)
					{
						max = i;
						num++;
					}
				}
				//Console.WriteLine($"{num}, {max}");
			}
			void CarType() //2.
			{
				Console.WriteLine(string.Join("\n", allstats));
			}
			void SortTypes() //3.
			{
				SortedDictionary<int, List<Vehicle>> collection = [];
				foreach(var car in allcars)
				{
					if(!collection.ContainsKey(car.ArrivesInDays))
					{
						collection[car.ArrivesInDays] = [];
					}
					collection[car.ArrivesInDays].Add(car);
				}
				foreach(var arrive in collection.Keys)
				{
					Console.WriteLine($"\nThese cars have arrived on day {arrive}:");
					foreach(var a in collection[arrive])
					{
						Console.WriteLine(a);
					}
				}
			}
			Days();
			Console.Write("\n");
			CarType();
			SortTypes();

			int user = int.Parse(Console.ReadLine());
			SortedDictionary<int, List<Vehicle>> collection = [];
			foreach (var car in allcars)
			{
				if (!collection.ContainsKey(car.ArrivesInDays))
				{
					collection[car.ArrivesInDays] = [];
				}
				collection[car.ArrivesInDays].Add(car);
			}
			if(collection.ContainsKey(user))
			{
				foreach(var j in collection[user])
				{
					Console.WriteLine(j);
				}
			}
			else
			{
				Console.WriteLine($"ERROR!\nDay {user} doesn't exist!");
			}

			//Console.WriteLine(string.Join("\n",allstats));
			Console.ReadKey();
        }
    }
}
