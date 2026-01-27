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
		public Ad(int area, Category category, DateTime createat, string desc, int floors, bool freeofcharge, int id, string imgurl, string latlong, int rooms, Seller seller)
		{
			Area = area;
			Category = category;
			CreateAt = createat;
			Description = desc;
			Floors = floors;
			FreeOfCharge = freeofcharge;
			ID = id;
			ImageURL = imgurl;
			LatLong = latlong;
			Rooms = rooms;
			Seller = seller;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            
			Console.ReadKey();
        }
    }
}
