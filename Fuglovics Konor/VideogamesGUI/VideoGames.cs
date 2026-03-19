using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideogamesGUI
{
	public class VideoGames
	{
		public string Name
		{
			get;
			set;
		}
		public string Console
		{
			get;
			set;
		}
		public string Genre
		{
			get;
			set;
		}
		public string Publisher
		{
			get;
			set;
		}
		public string Developer
		{
			get;
			set;
		}
		public double CriticScore
		{
			get;
			set;
		}
		public double AllSoldMillions
		{
			get;
			set;
		}
		public int ReleaseYear
		{
			get;
			set;
		}
		public VideoGames(string name, string console, string genre, string pub, string dev, double criticpt, double total_sold_m, int year)
		{
			Name = name;
			Console = console;
			Genre = genre;
			Publisher = pub;
			Developer = dev;
			CriticScore = criticpt;
			AllSoldMillions = total_sold_m;
			ReleaseYear = year;
		}
	}
}
