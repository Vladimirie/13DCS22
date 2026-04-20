namespace Olimpia2020
{
	internal class Olympics
	{
		public string Country
		{
			get;
			set;
		}
		public int Gold
		{
			get;
			set;
		}
		public int Silver
		{
			get;
			set;
		}
		public int Bronze
		{
			get;
			set;
		}
		public int Total
		{
			get;
			set;
		}
		public Olympics(string country, int gold, int silver, int bronze, int total)
		{
			Country = country;
			Gold = gold;
			Silver = silver;
			Bronze = bronze;
			Total = total;
		}
	}
}
