using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcoholism
{
	internal class Alkohol
	{
		public string Ország
		{
			get;
			set;
		}
		public int Söradagok
		{
			get;
			set;
		}
		public int Égetett_szesz
		{
			get;
			set;
		}
		public int Boradagok
		{
			get;
			set;
		}
		public double Tiszta_alkohol_Liter
		{
			get;
			set;
		}
		public Alkohol(string ország, int söradagok, int égetett_szesz, int boradagok, double tiszta_alkohol_liter)
		{
			Ország = ország;
			Söradagok = söradagok;
			Égetett_szesz = égetett_szesz;
			Boradagok = boradagok;
			Tiszta_alkohol_Liter = tiszta_alkohol_liter;
		}
	}
}
