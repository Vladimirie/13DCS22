using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Pomelo.EntityFrameworkCore.MySql;

namespace Fáj_ha_linQzok
{
    class Program
    {
        static void Main(string[] args)
        {

            using var db = new KulturDbContex();

       


            var irodalom = db.Feladatsor.Where(fe => fe.Ag == "irodalom").Select(fe => fe.Nevado);
            Console.WriteLine("1. feladat:" + string.Join("\n", irodalom));
            Console.WriteLine("Count " + irodalom.Count());
            var csipetCsapat = db.Csapat.Where(cs => cs.Tagszam >= 4).OrderBy(cs => cs.Nev).Select(cs => cs.Nev);
            Console.WriteLine("2. feladat:" + string.Join("\n", csipetCsapat));
            Console.WriteLine("Count " + csipetCsapat.Count());
            var perfectSulution = db.Megoldas.Join(db.Feladat, m => m.Feladatid, f => f.Id, (m, f) => new { mpont = m.Pontszam, fpoon = f.Pontszam, Id = m.Id }).Where(g => g.fpoon == g.mpont).Select(h => h.Id);
            Console.WriteLine("3. feladat:" + string.Join("\n", perfectSulution));
            Console.WriteLine("Count " + perfectSulution.Count());
            var kiCsinaltaEzt = db.Feladat.Join(db.Feladatsor, f => f.Feladatsorid, fs => fs.Id, (f, fs) => new { Nevado = fs.Nevado, f.Pontszam });
            Console.WriteLine("4. feladat:" + string.Join("\n", kiCsinaltaEzt));
            Console.WriteLine("Count " + kiCsinaltaEzt.Count());
            var yesKing = db.Csapat.Where(cs => cs.Nev == "Királyok").Join(db.Megoldas, cs => cs.Id, m => m.Csapatid, (cs, m) => new { Dátum = m.Datum, Pontszam = m.Pontszam });
            Console.WriteLine("5. feladat:" + string.Join("\n", yesKing));
            Console.WriteLine("Count " + yesKing.Count());
            var keses = db.Megoldas.Join(db.Feladat, m => m.Feladatid, f => f.Id, (m, f) => new { m, f }).Join(db.Feladatsor, j => j.f.Feladatsorid, fs => fs.Id, (j, fs) => new { j, fs }).Where(g => g.fs.Hatarido < g.j.m.Datum).Select(g => new { g.fs.Nevado, g.fs.Hatarido, g.j.m.Datum });
            Console.WriteLine("6. feladat:" + string.Join("\n", keses));
            Console.WriteLine("Count " + keses.Count());
        }
    }


}
