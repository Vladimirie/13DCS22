using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
            *//*
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

            */

            //   ||| Éretségi feladat ||| ///


            var a12 = db.Vizsgazo.Where(vizsgazo => vizsgazo.Evfolyam == 12 && vizsgazo.Osztaly == "A").OrderBy(vizsazo => vizsazo.Diaknev).Select(vizsgazo =>  vizsgazo.Diaknev).ToList();
            Console.WriteLine("12. A osztályosok:" + string.Join("\n", a12));
            Console.WriteLine( a12.Count());
            // var tori = db.Vizsgak.Where(vi => vi.Vizsgatargy == "történelem").Select(vi => vi.Id);
           // Console.WriteLine("Történelem vizsgák:" + tori.Count());
            var tori = db.Vizsgak.Where(vi => vi.Vizsgatargy == "történelem").Count();
            Console.WriteLine("Történelem vizsgák:" +tori);

            var smiths = db.Vizsgazo.Where(smit => smit.Diaknev.Contains("Kovács")).Select(smith => new { Diáknév = smith.Diaknev, ID = smith.Id });
           // Console.WriteLine("Kovácsok:" + string.Join("\n", smiths));
            foreach (var vi in smiths) {
                Console.WriteLine(vi.ID + "  " + vi.Diáknév);
            }
            Console.WriteLine(smiths.Count());
         //    var theG = db.Tanar.Where(g => g.Id[0] == 'G').Select(g => g.Nev).ToList();
            var theG = db.Tanar.Where(g => g.Id.ToUpper().StartsWith("G")).Select(g => g.Nev).ToList();
            Console.WriteLine("Tanárok kódjai:" + string.Join("\n", theG));

            Console.WriteLine(theG.Count());
            var tBiz = db.Vizsgak.Select(vi => vi.Bizottsag).Distinct().ToList();//toHASAT
            Console.WriteLine("Tanárok kódjai:" + string.Join("\n", tBiz));
            Console.WriteLine(tBiz.Count());
            var statiszika = db.Vizsgazo.GroupBy(v => new { v.Evfolyam, v.Osztaly }).Select(v => new { Évfolyam = v.Key.Evfolyam, Osztály = v.Key.Osztaly, Darab = v.Count() }).ToList();
            Console.WriteLine("Osztálylétszámok:" + string.Join("\n", statiszika));
            Console.WriteLine(statiszika.Count());
            var stat2 = from d in db.Vizsgazo
                        group d by new { d.Evfolyam, d.Osztaly } into diakcsoport
                        select new
                        {
                            Evfolyam = diakcsoport.Key.Evfolyam, Osztaly = diakcsoport.Key.Osztaly, Darab = diakcsoport.Count()
                        };
            Console.WriteLine("Osztálylétszámok:" + string.Join("\n", stat2));
            var tanvizs = db.Vizsgak.GroupBy(v => v.Vizsgatargy).OrderBy(v => v.Count()).Select(v => new { Tantárgy = v.Key, Darab = v.Count() });
            Console.WriteLine("Melyik tantárgyból szervezik a legtöbb vizsgát?:" + string.Join("\n", tanvizs.Last()));
            var vizstanar = db.Vizsgak.GroupBy(v => v.Tanarid).OrderByDescending(v => v.Key).Select(v => new {TanárId = v.Key,Darab = v.Count() }).ToList();
            Console.WriteLine("Rendezd csökkenő sorrendbe a tanárokat:" + string.Join("\n", vizstanar));
            //Join(db.Tanar, v => v.Tanarid, t => t.Id, (v, t) => t.Nev)
            var Join = db.Vizsgazo.Join(db.Vizsgak, vi => vi.Id, v => v.Vizsgazoid, (vi, v) => new {vi, v}).Join(db.Tanar, c => c.v.Tanarid ,t => t.Id, (c, t) => new {t.Nev, c.v.Vizsgatargy, c.vi.Diaknev});//lehet select de nem kell
            Console.WriteLine("Ki vizsgáztat kit?:" + string.Join("\n", Join));


        }
    }
   

}
