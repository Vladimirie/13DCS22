namespace RealEstateGUI
{
	public class Seller
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
}