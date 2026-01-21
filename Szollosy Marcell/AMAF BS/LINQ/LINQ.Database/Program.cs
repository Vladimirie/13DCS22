
using System.Data.Common;
using System.Numerics;
using Test0106;

class Program
{
    static void Main(string[] args)
    {
        using var db = new ErettsegiDbContext();
        //proba
        /*
            SELECT nev
            FROM tanar
        */
        //          FROM tanar   SELECT tanar.Nev       
        //              |               |
        var nevek = db.Tanar.Select(t => t.Nev).ToList();
        Console.WriteLine(string.Join("\n", nevek));

        var nevsor = db.Vizsgazo
                .Where(v => v.Evfolyam == 12 && v.Osztaly == "D")
                .OrderBy(v => v.DiakNev)
                .Select(v => v.DiakNev);

        Console.WriteLine("2. feladat:\n " + string.Join("\n", nevsor));

        var letszamok = db.Vizsgazo
        .Where(v => v.Evfolyam == 12)
        .GroupBy(v => v.Osztaly)
        .Select(g => new
        {
            Evfolyam = 12,      // Mivel szűrtünk rá, tudjuk, hogy ez fixen 12
            Osztaly = g.Key,    // A .Key az, ami alapján csoportosítottunk (az osztály jele)
            Letszam = g.Count() // Ez felel meg a COUNT(*)-nak
        })
        .ToList();

        Console.WriteLine("3. feladat:\n" + string.Join("\n", letszamok));

        var angolTanarok = db.Vizsgak
        // 1. Először szűrünk (csak angol vizsgák), hogy kevesebb adatot kelljen összekötni
        .Where(v => v.VizsgaTargy == "angol nyelv")

        // 2. Összekötjük a Tanárokkal
        .Join(db.Tanar,          // Kivel kötjük össze?
              v => v.TanarId,      // Vizsga oldali kulcs
              t => t.Id,           // Tanár oldali kulcs
              (v, t) => t.Nev)     // Mi az eredmény? (Csak a tanár neve)

        // 3. Kivesszük az ismétlődéseket
        .Distinct()

        .ToList();

        Console.WriteLine("4. feladat:\n" + string.Join("\n", angolTanarok));

        var tobb3 = db.Vizsgazo
                .Join(db.Vizsgak,
                vizsgazo => vizsgazo.Id,
                vizsga => vizsga.VizsgazoId,
                (vizsga, vizsgazo) => new {vizsga, vizsgazo})
                .GroupBy(v => v.vizsgazo.VizsgazoId)
                .Where(g => g.Count() > 3)
                .Select(g => new
                {
                    Nev = g.Key.
                });












        //2. feladat
        /*
        var nevsor = db.Vizsgazo
        .Where(v => v.Evfolyam == 12 && v.Osztaly == "D")
        .OrderBy(v => v.DiakNev)
        .Select(v => v.DiakNev)
        .ToList();

        System.Console.WriteLine($"2. feladat: {string.Join("\n", nevsor)}" );
        */
    }

}