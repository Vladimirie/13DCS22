namespace SQLProgram
{
	internal class Teachers
	{
		public string ID
		{
			get;
			set;
		}
		public string Név
		{
			get;
			set;
		}
	}
	internal class Exams
	{
		public int ID
		{
			get;
			set;
		}
		public string Bizottság
		{
			get;
			set;
		}
		public string Vizsgatárgy
		{
			get;
			set;
		}
		public int VizsgázóID
		{
			get;
			set;
		}
		public string TanárID
		{
			get;
			set;
		}
	}
	internal class Students
	{
		public int ID
		{
			get;
			set;
		}
		public string Diáknév
		{
			get;
			set;
		}
		public int Évfolyam
		{
			get;
			set;
		}
		public string Osztály
		{
			get;
			set;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            using var database = new GraduationDbContext();
			var names = from tanar in database.Tanár
						select tanar.Név;
			var query1 = from student in database.Vizsgázó
						where student.Évfolyam == 12 && student.Osztály == "D"
						orderby student.Diáknév ascending
						select student.Diáknév;
			var query2 = from student in database.Vizsgázó
						where student.Évfolyam == 12
						group student by student.Osztály into studentgrp
						select new
						{
							Évfolyam = 12,
							Darab = studentgrp.Count(),
							Osztály = studentgrp.Key
						};
			var query3 = (from tanar in database.Tanár
						 from vizsga in database.Vizsgák
						 where tanar.ID == vizsga.TanárID && vizsga.Vizsgatárgy == "angol nyelv"
						 select tanar.Név).Distinct();
			/*
				SELECT COUNT(vizsgatargy), diaknev, evfolyam, osztaly
				FROM vizsgazo, vizsgak WHERE vizsgazoid = vizsgazo.id
				GROUP BY diaknev, evfolyam, osztaly
				HAVING COUNT(vizsgatargy) > 3
			*/
			var query4 = from vizsgazo in database.Vizsgázó
						 from vizsgak in database.Vizsgák
						 where vizsgak.VizsgázóID == vizsgazo.ID
						 group vizsgazo by new 
						 {
							 vizsgazo.Diáknév,
							 vizsgazo.Évfolyam,
							 vizsgazo.Osztály
						 }
						 into g
						 where g.Count() > 3
						 select new
						 {
							 Vizsgaszám = g.Count(),
							 Név = g.Key.Diáknév,
							 Évfolyam = g.Key.Évfolyam,
							 Osztály = g.Key.Osztály
						 };
			Console.WriteLine($"{string.Join("\n", query1)}\n");
			foreach(var name in query2)
			{
				Console.WriteLine($"{name.Évfolyam}\t{name.Osztály}\t{name.Darab}");
			}
			Console.WriteLine($"{string.Join("\n", query3)}\n");
			foreach (var name in query4)
			{
				Console.WriteLine($"{name.Évfolyam}\t{name.Osztály}\t{name.Név}");
			}
			Console.ReadKey();
        }
    }
}
