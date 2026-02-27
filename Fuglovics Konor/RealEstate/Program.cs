namespace RealEstate
{
	internal class Category
	{
		public int ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public Category(int id, string name)
		{
			ID = id;
			Name = name;
		}
	}
	internal class Seller
	{
		public int ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Phone
		{
			get;
			set;
		}
		public Seller(int id, string name, string phone)
		{
			ID = id;
			Name = name;
			Phone = phone;
		}
	}
	internal class Ad
	{
		public int Area
		{
			get;
			set;
		}
		public Category Category
		{
			get;
			set;
		}
		public DateTime CreateAt
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public int Floors
		{
			get;
			set;
		}
		public bool FreeOfCharge
		{
			get;
			set;
		}
		public int ID
		{
			get;
			set;
		}
		public string ImageURL
		{
			get;
			set;
		}
		public string LatLong
		{
			get;
			set;
		}
		public int Rooms
		{
			get;
			set;
		}
		public Seller Seller
		{
			get;
			set;
		}
		public Ad(int id, int rooms, string latlong, int floors, int area, string desc, bool freeofcharge, string imgurl, DateTime createat, Seller seller, Category category)
		{
			ID = id;
			Rooms = rooms;
			LatLong = latlong;
			Floors = floors;
			Area = area;
			Description = desc;
			FreeOfCharge = freeofcharge;
			ImageURL = imgurl;
			CreateAt = createat;
			Seller = seller;
			Category = category;
		}
		public Ad()
		{

		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> adlist = [];
			foreach(var ad in File.ReadAllLines("realestates.csv").Skip(1))
			{
				string[] line = ad.Split(";");
				adlist.Add(new Ad
				(
					int.Parse(line[0]), 
					int.Parse(line[1]), 
					line[2], 
					int.Parse(line[3]), 
					int.Parse(line[4]), 
					line[5], 
					Convert.ToBoolean(int.Parse(line[6])), 
					line[7], 
					Convert.ToDateTime(line[8]), 
					new Seller(int.Parse(line[9]), line[10], line[11]), 
					new Category(int.Parse(line[12]), line[13]))
				);
			}
			Console.WriteLine(string.Join("\n",adlist.Select(a => a.Area)));
			/*int avg = 0;
			int count = 0;
			foreach(var avrg in adlist)
			{
				if(avrg.Floors == 0)
				{
					avg += avrg.Area;
				count++;
				}
			}
			Console.WriteLine($"Average area: {avg/count} m²");*/
			Console.WriteLine($"Average area: {Math.Round(adlist.Where(a => a.Floors == 0).Average(a => a.Area),2)} m²");
			double x = 47.4164220114023;
			double y = 19.066342425796986;
			var mindist = double.MaxValue;
			Ad minads = new Ad();
			foreach(var a in adlist)
			{
				double d = DistanceTo(a.LatLong, x, y);
				if(d < mindist)
				{
					mindist = d;
					minads = a;
				}
			}
			Console.WriteLine($"The Mesevár Kindergarten's closest estate's data:\n\tSeller's Name:\t{minads.Seller.Name}");
			Console.ReadKey();
        }
		public static double DistanceTo(string latlong, double x, double y)
		{
			latlong = latlong.Replace(",", ";");
			//latlong = latlong.Replace(".", ",");
			string[] coord = latlong.Split(";");
			double latitude = double.Parse(coord[0]);
			double longitude = double.Parse(coord[1]);
			return Math.Sqrt(Math.Pow((x - latitude),2)+ Math.Pow((y - longitude),2));
		}
    }
}
