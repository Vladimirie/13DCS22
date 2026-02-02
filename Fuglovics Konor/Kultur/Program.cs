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
					 from e in ab.Feladat
					 where c.CsapatID == d.ID
					 && e.Pontszam == c.Pontszam
					 group d by new
					 {
						 d.Nev,
						 e.Pontszam
					 } into grp
					 select new
					 {
						 grp.Key,
						 grp.Key.Pontszam
					 };
			Console.WriteLine("\nNév\t\tPontszám");
			foreach (var i in _3)
			{
				if (i.Key.Nev.Length < 8)
				{
					Console.WriteLine($"{i.Key.Nev}\t\t{i.Key.Pontszam}");
				}
				else
				{
					Console.WriteLine($"{i.Key.Nev}\t{i.Key.Pontszam}");
				}
			}
			var _4 = from f in ab.Feladatsor
					 from g in ab.Feladat
					 where g.FeladatsorID == f.ID
					 orderby g.ID
					 select new
					 {
						 g.ID,
						 f.Nevado,
						 g.Pontszam
					 };
			Console.WriteLine($"\nFel. ID\tNévadó\t\t\t\tPontszám");
			foreach(var i in _4)
			{
				if(i.Nevado.Length < 8)
				{
					Console.WriteLine($"{i.ID}\t{i.Nevado}\t\t\t\t{i.Pontszam}");
				}
				else if(i.Nevado.Length < 16)
				{
					Console.WriteLine($"{i.ID}\t{i.Nevado}\t\t\t{i.Pontszam}");
				}
				else if(i.Nevado.Length < 24)
				{
					Console.WriteLine($"{i.ID}\t{i.Nevado}\t\t{i.Pontszam}");
				}
				else
				{
					Console.WriteLine($"{i.ID}\t{i.Nevado}\t{i.Pontszam}");
				}
			}
			Console.ReadKey();
        }
    }
}
