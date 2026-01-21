using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace Zulu
{
    class Program
    {
        static void Main(string[] args)
        {

            using var db = new ErettsegiDbContext();

            /*
            var nevek = db.Tanar.Select( tanar => tanar.Nev).ToList();
            Console.WriteLine(string.Join("\n", nevek));
            */
            //    SELECT `diaknev` FROM `vizsgazo` Where vizsgazo.osztaly = "D" ORDER BY diaknev;
            var nevsor = db.Vizsgazo.Where(v => v.Evfolyam == 12 && v.Osztaly == "D").OrderBy(v => v.Diaknev).Select(v => v.Diaknev).ToList();
            Console.WriteLine("2 es feladat " + string.Join("\n", nevsor));
            //  SELECT COUNT(`diaknev`), osztaly, `evfolyam`  FROM `vizsgazo` WHERE `evfolyam` = 12 GROUP by `osztaly`;
            var vizsgazokcount = db.Vizsgazo.Where(v => v.Evfolyam == 12).GroupBy(v => v.Osztaly).Select(g => new { betujel = g.Key, Letszam = g.Count(), Evfolyam = 12 }).ToList();


            Console.WriteLine("3 mas feladat " + string.Join("\n", vizsgazokcount));
            // SELECT DISTINCT tanar.nev FROM tanar , vizsgak WHERE tanar.id = vizsgak.tanarid AND vizsgak.vizsgatargy = "angol nyelv";
            var tanarang = db.Vizsgak.Where(v => v.Vizsgatargy == "angol nyelv").Join(db.Tanar, v => v.Tanarid, t => t.Id, (v, t) => t.Nev).Distinct().ToList();
            Console.WriteLine("4 es feladat " + string.Join("\n", tanarang));
            // SELECT vizsgazo.diaknev , vizsgazo.evfolyam ,vizsgazo.osztaly FROM vizsgazo, vizsgak WHERE vizsgazo.id = vizsgak.vizsgazoid GROUP BY diaknev HAVING COUNT(vizsgak.vizsgatargy) > 3;
            // var tobb3 = db.Vizsgazo.        }
        }
    }
   

}
