using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeWPF
{
	public class Bridge
	{
		public int Position {get; set;}
		public string Name {get; set;}
		public string Location {get; set;}
		public string Country {get; set;}
		public int Length {get; set;}
		public int Year {get; set;}
		public Bridge(int pos, string name, string location, string country, int len, int year)
		{
			Position = pos;
			Name = name;
			Location = location;
			Country = country;
			Length = len;
			Year = year;
		}
	}
}
