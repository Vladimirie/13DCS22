using Kulturforras;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kulturforras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new KulturforrasDbContext();

            //1. Feladat: Listázd ki az összes "irodalom" ághoz tartozó feladatsor nevét.
            /*var feladat1 = db.FeladatSor
            .Where(f => f.AG == "irodalom")
            .Select(f => f.NevAdo)
            .ToList();

            feladat1.ForEach(Console.WriteLine);
            */
            //2. Feladat:  Melyek azok a csapatok, ahol a tagok száma eléri vagy meghaladja a 4 főt? Rendezd őket névsorba.
            /*var feladat2 = db.Csapat
            .Where(c => c.TagSzam >= 4)
            .OrderBy(c => c.Nev)
            .Select(c => c.Nev)
            .ToList();

            feladat2.ForEach(Console.WriteLine);
            */
            //3. Feladat: Listázd ki azokat a megoldásokat, ahol a csapat maximális pontszámot (például 40 pontot) ért el.
            /*var maxPontMegoldasok = db.Megoldas
            .GroupBy(m => m.CsapatId)
            .Select(g => new
            {  
             CsapatId = g.Key,
                MaxPontszam = g.Max(m => m.PontSzam)
            })
            .Join(db.Megoldas,
                 g => new { g.CsapatId, Pontszam = g.MaxPontszam },
                 m => new { m.CsapatId, Pontszam = m.PontSzam },
                 (g, m) => new
                {
              MegoldasId = m.Id,
              CsapatId = m.CsapatId,
              Pontszam = m.PontSzam
             })
            .ToList();

            foreach (var m in maxPontMegoldasok)
            {
                Console.WriteLine($"Megoldás ID: {m.MegoldasId}, Csapat ID: {m.CsapatId}, Pont: {m.Pontszam}");
            }
            */
            //4. Feladat: Listázd ki az összes feladatot, és mellé írd ki, hogy melyik feladatsorhoz tartoznak (pl. "Bartók Béla - 15 pont").
            var feladat4 = db.Feladat
            .Join(db.FeladatSor,
             f => f.FeladatSorId,
             fs => fs.Id,
             (f, fs) => $"{fs.NevAdo} - {f.PontSzam} pont")
            .ToList();

            feladat4.ForEach(Console.WriteLine);

            //5. Feladat:  Készíts egy listát a "Királyok" nevű csapat által beadott összes megoldásról. A listában szerepeljen a megoldás dátuma és a kapott pontszám.

            //6. Feladat: Keress olyan megoldásokat, amelyeket a hozzájuk tartozó feladatsor határideje után adtak be(késedelmes beadások).

            //7. Feladat: Áganként (pl. irodalom, zene) hány feladatsor került meghirdetésre?

            //8. Feladat: Mennyi az egyes feladatsorokon szerezhető maximális összpontszám? (A feladat tábla pontszam mezőinek összege feladatsoronként).

            //9. Feladat: Csapat ranglista! Melyik csapat hány pontot gyűjtött összesen az összes feladatból? Rendezd csökkenő sorrendbe a szerzett pontok alapján.

            //10. Feladat:  Melyik az a feladatsor, amelyre a legkevesebb megoldás érkezett?

            //11. Feladat: Van-e olyan csapat, amelyik minden "történelem" (vagy más specifikus, pl."képzőművészet") ághoz tartozó feladatsorból legalább egy feladatot megoldott ?

            //12. Feladat: Számítsd ki a "százalékos teljesítményt" minden egyes megoldáshoz! (Szerzett pont / Feladat max pontja *100). Listázd ki azokat, ahol ez az érték 100 %.
        }
    }
}
