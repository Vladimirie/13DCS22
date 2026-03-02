namespace Érettségi
{
	internal class Teacher
	{
		public char ID {get; set;}
		public string Név {get; set;}
	}
	internal class Exams
	{
		public int ID {get; set;}
		public string Bizottság {get; set;}
		public string Vizsgatárgy {get; set;}
		public int VizsgázóID {get; set;}
		public char TanárID {get; set;}
	}
	internal class Student
	{
		public int ID { get; set; }
		public string Diáknév { get; set; }
		public int Évfolyam { get; set; }
		public char Osztály { get; set; }
	}
    internal class Program
    {
        static void Main(string[] args)
        {
			/*
			 12. A osztályosok: Listázd ki az összes 12. évfolyamos, "A" osztályos tanuló nevét ábécé sorrendben!

			 Történelem vizsgák: Hány darab történelem vizsga szerepel összesen a vizsgak listában?

			 Kovácsok: Listázd ki azon diákok nevét és azonosítóját, akiknek a neve tartalmazza a "Kovács" szót!

			 Tanárok kódjai: Írasd ki azon tanárok nevét, akiknek a kódja (ID) "G" betűvel kezdődik.

			 Vizsgabizottságok: Milyen különböző vizsgabizottságok (pl. "12C", "12D") léteznek a vizsgak táblában?
			 */
			using var database = new GraduationDbContext();
			var _12D =
				from a in database.Vizsgázó
				where a.Évfolyam == 12 && a.Osztály == 'A'
				orderby a.Diáknév ascending
				select new
				{
					Év = a.Évfolyam,
					Oszt = a.Osztály,
					Név = a.Diáknév
				};
			Console.WriteLine("1.");
			foreach(var i in _12D)
			{
				Console.WriteLine($"{i.Év}\t{i.Oszt}\t{i.Név}");
			}
			var history =
				from b in database.Vizsgák
				where b.Vizsgatárgy == "történelem"
				select b.Vizsgatárgy;
			Console.WriteLine("\n2.");
			Console.WriteLine(history.Count());
			var smith =
				from c in database.Vizsgázó
				where c.Diáknév.Substring(0,6) == "Kovács"
				select new
				{
					c.ID,
					c.Diáknév
				};
			Console.WriteLine("\n3.\nID\tNév");
			foreach(var i in smith)
			{
				Console.WriteLine($"{i.ID}\t{i.Diáknév}");
			}
			var code =
				from d in database.Tanár
				where d.ID.ToString().StartsWith("G")
				select d.Név;
			Console.WriteLine("\n4.");
			Console.WriteLine(string.Join("\n", code));
			var classes =
				from e in database.Vizsgák
				select e.Bizottság;
			Console.WriteLine("\n5.");
			Console.WriteLine(string.Join("\n", classes.Distinct()));
			/*
			Osztálylétszámok: Készíts statisztikát: évfolyamonként és osztályonként hány diák van az adatbázisban? (Pl. 12. A: 15 fő, 11. B: 10 fő...).
 
			Melyik tantárgyból szervezik a legtöbb vizsgát? Írasd ki a tantárgy nevét és a vizsgák számát.
 
			Rendezd csökkenő sorrendbe a tanárokat aszerint, hogy hány vizsgáztatást vállaltak (a vizsgak listában hányszor szerepel a TanarId). Csak a tanár kódja és a darabszám kell.
			*/
			var group =
				from f in database.Vizsgázó
				group f by new
				{
					f.Évfolyam,
					f.Osztály
				}
				into grp
				select new
				{
					Év = grp.Key.Évfolyam,
					Oszt = grp.Key.Osztály,
					Db = grp.Count()
				};
			Console.WriteLine("\n6.");
			foreach(var i in group)
			{
				Console.WriteLine($"{i.Év}/{i.Oszt}\t{i.Db} db");
			}
			var mostexams =
				from g in database.Vizsgák
				group g by g.Vizsgatárgy into exams
				orderby exams.Count() descending
				select new
				{
					Tantárgy = exams.Key,
					Darab = exams.Count()
				};
			Console.WriteLine("\n7.");
			var solution = mostexams.First();
			foreach(var i in mostexams)
			{
				Console.WriteLine($"{i.Tantárgy}, {i.Darab} db");
			}
			Console.WriteLine(solution);
			var teacherexams =
				from h in database.Vizsgák
				from i in database.Tanár
				where h.TanárID == i.ID
				group h by new
				{
					h.Vizsgatárgy,
					i.Név
				}
				into data
				orderby data.Count() descending
				select new
				{
					Tanár = data.Key.Név,
					Db = data.Count()
				};
			Console.WriteLine("\n8.\nTanár\t\t\tDarabszám");
			foreach(var i in teacherexams)
			{
				if(i.Tanár.Length >= 16)
				{
					Console.WriteLine($"{i.Tanár}\t{i.Db}");
				}
				else
				{
					Console.WriteLine($"{i.Tanár}\t\t{i.Db}");
				}
			}
			/*
			Ki vizsgáztat kit?: Listázd ki az összes vizsga adatait így: Diák Neve - Tantárgy - Tanár Neve.
 
			"Kiss" nevűek angol vizsgái: Keress minden olyan vizsgát, ahol a tárgy "angol nyelv", és a
			diák neve tartalmazza a "Kiss" szót. Az eredményben a diák neve és a vizsgáztató tanár neve szerepeljen.
 
			Görög Pál vizsgái: Listázd ki az összes olyan diák nevét és osztályát, akit "Görög Pál" (TanarId keresése név alapján)
			vizsgáztatott bármilyen tárgyból.
			*/
			var examrelship =
				from j in database.Tanár
				from k in database.Vizsgák
				from l in database.Vizsgázó
				where k.VizsgázóID == l.ID && k.TanárID == j.ID
				group k by new
				{
					l.Diáknév,
					k.Vizsgatárgy,
					j.Név
				}
				into list
				select new
				{
					Tanuló = list.Key.Diáknév,
					Tan = list.Key.Vizsgatárgy,
					Tanár = list.Key.Név
				};
			Console.WriteLine("\n9.\nDiák Neve\t\t\tTantárgy\t\t\tTanár Neve");
			foreach(var i in examrelship)
			{
				Console.WriteLine($"{i.Tanuló}\t\t\t{i.Tan}\t\t\t{i.Tanár}");
			}
			Console.ReadKey();
		}
    }
}
