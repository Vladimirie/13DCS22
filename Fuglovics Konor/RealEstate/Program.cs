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
		public double LatLong
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
		public Ad(int id, int rooms, double latlong, int floors, int area, string desc, bool freeofcharge, string imgurl, DateTime createat, Seller seller, Category category)
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
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> adlist = [];
			foreach(var ad in File.ReadAllLines("realestates.csv"))
			{
				string[] line = ad.Split(";");
				adlist.Add(new Ad
				(
					int.Parse(line[0]), 
					int.Parse(line[1]), 
					double.Parse(line[2]), 
					int.Parse(line[3]), 
					int.Parse(line[4]), 
					line[5], 
					Convert.ToBoolean(line[6]), 
					line[7], 
					Convert.ToDateTime(line[8]), 
					new Seller(int.Parse(line[9]), line[10], line[11]), 
					new Category(int.Parse(line[12]), line[13]))
				);
			}
			Console.ReadKey();
        }
    }
}
