using Erettsegi;

namespace erettsegi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new ErettsegiDbContext();

            //1. Feladat: Listázd ki az összes 12. évfolyamos, "A" osztályos tanuló nevét ábécé sorrendben!
            /*var feladat1 = db.Vizsgazo
                .Where(diak => diak.EvFolyam == 12 && diak.Osztaly == "A")
                .OrderBy(diak => diak.DiakNev)
                .Select(diak => diak.DiakNev);
            Console.WriteLine("\n" + string.Join("\n", feladat1));*/


            //2. Feladat: Hány darab történelem vizsga szerepel összesen a vizsgak listában?
            /*var feladat2 = db.Vizsgak
               .Count(v => v.Vizsgatargy == "történelem");

           Console.WriteLine($"2. feladat: Történelem vizsgák száma: {feladat2}");*/

            //3. Feladat: Listázd ki azon diákok nevét és azonosítóját, akiknek a neve tartalmazza a "Kovács" szót!
            /*var feladat3 = db.Vizsgazo
           .Where(d => d.DiakNev.Contains("Kovács"))
           .Select(d => new { d.Id, d.DiakNev })
           .ToList();

           Console.WriteLine("3. feladat:");
           foreach (var d in feladat3)
           {
               Console.WriteLine($"{d.Id} - {d.DiakNev}");
           }*/

            //4. Feladat: Írasd ki azon tanárok nevét, akiknek a kódja (ID) "G" betűvel kezdődik.
            /*var feladat4 = db.Tanar
            .Where(t => t.Id.StartsWith("G"))
             .Select(t => t.Nev)
               .ToList();

            Console.WriteLine("4. feladat:");
            feladat4.ForEach(n => Console.WriteLine(n));*/


            //5. Feladat: Milyen különböző vizsgabizottságok (pl. "12C", "12D") léteznek a vizsgak táblában?
            /*var feladat5 = db.Vizsgak
            .Select(v => v.Bizottsag)
            .Distinct()
            .OrderBy(b => b)
            .ToList();

            Console.WriteLine("5. feladat: Vizsgabizottságok:");
            feladat5.ForEach(b => Console.WriteLine(b));*/

            //6. Feladat: Osztálylétszámok: Készíts statisztikát: évfolyamonként és osztályonként hány diák van az adatbázisban? (Pl. 12. A: 15 fő, 11. B: 10 fő...).
            var feladat5 = db.Vizsgazo
            .GroupBy(d => new { d.EvFolyam, d.Osztaly })
             .Select(g => new
             {
               g.Key.EvFolyam,
                g.Key.Osztaly,
                Letszam = g.Count()
             })
            .OrderBy(g => g.EvFolyam)
            .ThenBy(g => g.Osztaly)
            .ToList();

            Console.WriteLine("Osztálylétszámok:");
            foreach (var l in feladat5)
            {
                Console.WriteLine($"{l.EvFolyam}. {l.Osztaly}: {l.Letszam} fő");
            }


            //7. Feladat: Melyik tantárgyból szervezik a legtöbb vizsgát? Írasd ki a tantárgy nevét és a vizsgák számát.


            //8. Feladat: Rendezd csökkenő sorrendbe a tanárokat aszerint, hogy hány vizsgáztatást vállaltak (a vizsgak listában hányszor szerepel a TanarId). Csak a tanár kódja és a darabszám kell.


            //9. Feladat: Listázd ki az összes vizsga adatait így: Diák Neve - Tantárgy - Tanár Neve.


            //10. Feladat: Keress minden olyan vizsgát, ahol a tárgy "angol nyelv", és a diák neve tartalmazza a "Kiss" szót. Az eredményben a diák neve és a vizsgáztató tanár neve szerepeljen.


            //11. Feladat: Listázd ki az összes olyan diák nevét és osztályát, akit "Görög Pál" (TanarId keresése név alapján) vizsgáztatott bármilyen tárgyból.



        }

    }
}
