namespace Kultur
{
	internal class Test
	{
		public int ID {get; set;}
		public string Nevado {get; set;}
		public string Ag {get; set;}
		public DateTime Kituzes {get; set;}
		public DateTime Hatarido {get; set;}
	}
	internal class Assignment
	{
		public int ID {get; set;}
		public int FeladatsorID {get; set;}
		public int Pontszam {get; set;}
	}
	internal class Solution
	{
		public int ID {get; set;}
		public int FeladatID {get; set;}
		public int CsapatID {get; set;}
		public DateTime Datum {get; set;}
		public int Pontszam {get; set;}
	}
	internal class Team
	{
		public int ID {get; set;}
		public string Nev {get; set;}
		public int Tagszam {get; set;}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            using var ab = new KulturDbContext();
			var _1 = from a in ab.Feladatsor
					 where a.Ag == "irodalom"
					 select a.Nevado;
			Console.WriteLine(string.Join("\n",_1));
			var _2 = from b in ab.Csapat
					 where b.Tagszam >= 4
					 orderby b.Nev ascending
					 select new
					 {
						 b.Nev,
						 b.Tagszam
					 };
			Console.WriteLine("\nNév\t\tTagszám");
			foreach(var i in _2)
			{
				if(i.Nev.Length < 8)
				{
					Console.WriteLine($"{i.Nev}\t\t{i.Tagszam}");
				}
				else
				{
					Console.WriteLine($"{i.Nev}\t{i.Tagszam}");
				}
			}
			var _3 = from c in ab.Megoldas
					 from d in ab.Csapat
					 where c.CsapatID == d.ID
					 && c.Pontszam == 40;
			Console.ReadKey();
        }
    }
}
