namespace Fuvar
{
	internal class Delivery
	{
		public int ID
		{
			get;
			set;
		}
		public DateTime DateTime
		{
			get;
			set;
		}
		public int TravelSecs
		{
			get;
			set;
		}
		public float DistanceMi
		{
			get;
			set;
		}
		public float Fare
		{
			get;
			set;
		}
		public float Tip
		{
			get;
			set;
		}
		public string PurchaseType
		{
			get;
			set;
		}
		public Delivery(int id, DateTime datetime, int travelsecs, float distancemi, float fare, float tip, string purchasetype)
		{
			ID = id;
			DateTime = datetime;
			TravelSecs = travelsecs;
			DistanceMi = distancemi;
			Fare = fare;
			Tip = tip;
			PurchaseType = purchasetype;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Delivery> delilist = [];
			foreach(var data in File.ReadAllLines("fuvar.csv").Skip(1))
			{
				string[] line = data.Split(";");
				string[] dt = line[1].Split(" ");
				string[] date = dt[0].Split("-");
				string[] time = dt[1].Split(":");
				line[3] = line[3].Replace(",",".");
				line[4] = line[4].Replace(",",".");
				line[5] = line[5].Replace(",",".");
				delilist.Add(new Delivery
				(
					int.Parse(line[0]), 
					new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2])), 
					int.Parse(line[2]), 
					float.Parse(line[3]), 
					float.Parse(line[4]), 
					float.Parse(line[5]), 
					line[6])
				);
			}
			Console.WriteLine($"{delilist.Count} fuvar van összesen.");
			float allfare = 0;
			int a = 0;
			foreach(var deli in delilist)
			{
				if(deli.ID == 6185)
				{
					a++;
					allfare += deli.Fare;
				}
			}
			Console.WriteLine($"All {a} carriages' income: {allfare}$");
			int ccard = 0;
			int cash = 0;
			int rsonpay = 0;
			int free = 0;
			int undefined = 0;
			foreach(var types in delilist)
			{
				switch(types.PurchaseType)
				{
					case "bankkártya":
						ccard++;
						break;
					case "készpénz":
						cash++;
						break;
					case "vitatott":
						rsonpay++;
						break;
					case "ingyenes":
						free++;
						break;
					default:
						undefined++;
						break;
				}
			}
			Console.WriteLine($"Purch. typ\tAmount\n{}:\t{}");
			Console.ReadKey();
		}
    }
}
