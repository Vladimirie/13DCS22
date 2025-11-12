using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Autoapp
{
	class Cars
	{
		public int ID
		{
			get;
			private set;
		}
		public string Brand
		{
			get;
			private set;
		}
		public string Model
		{
			get;
			private set;
		}
		public int ProdYear
		{
			get;
			private set;
		}
		public string Color
		{
			get;
			private set;
		}
		public int SoldAmount
		{
			get;
			private set;
		}
		public int AvgPrice
		{
			get;
			private set;
		}
		public Cars(int id, string brand, string model, int prodyear, string color, int soldamount, int avgprice)
		{
			this.ID = id;
			this.Brand = brand;
			this.Model = model;
			this.ProdYear = prodyear;
			this.Color = color;
			this.SoldAmount = soldamount;
			this.AvgPrice = avgprice;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Cars> data = new List<Cars>();
			string[] csv = File.ReadAllLines("autok.csv");
			csv = csv.Skip(1).ToArray();
			foreach(var item in csv)
			{
				string[] clmn = item.Split(';');
				data.Add(new Cars(int.Parse(clmn[0]), clmn[1], clmn[2], int.Parse(clmn[3]), clmn[4], int.Parse(clmn[5]), int.Parse(clmn[6])));
			}
			foreach(var cars in data)
			{
				Console.WriteLine(cars.);
			}
			Console.WriteLine();
			Console.ReadKey();
		}
	}
}
