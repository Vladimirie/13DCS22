using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpia2020GUI
{
    internal class Olimpia
	{
		public string Ország
		{
			get;
			set;
		}
		public int Arany
		{
			get;
			set;
		}
		public int Ezüst
		{
			get;
			set;
		}
		public int Bronz
		{
			get;
			set;
		}
		public int Összesen
		{
			get;
			set;
		}
		public Olimpia(string ország, int arany, int ezüst, int bronz, int összesen)
		{
			Ország = ország;
			Arany = arany;
			Ezüst = ezüst;
			Bronz = bronz;
			Összesen = összesen;
		}
	}
}
