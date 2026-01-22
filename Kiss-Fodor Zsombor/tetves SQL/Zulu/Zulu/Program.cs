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
            //
            using var db = new ErettsegiDbContext();

            //
            var nevsor = db.Vizsgazo
                .Where(v => v.Evfolyam == 12 && v.Osztaly == "A")
                .OrderBy(v => v.Diaknev)
                .Select(v => v.Diaknev);
            Console.WriteLine("1-es feladat: " + string.Join("\n", nevsor));

            //
            var töricount = db.Vizsgak
                .Where(v => v.Vizsgatargy == "történelem")
                .Count();            
            Console.WriteLine("2-es feladat: " + string.Join("\n", töricount));

            //
            var kovacsok = db.Vizsgazo
                .Where(v => v.Diaknev.Contains("Kovács"))
                .Select(v => new {v.Diaknev, v.Id});
            Console.WriteLine("3-as feladat: " + string.Join ("\n", kovacsok));

            //
            var tanarok = db.Tanar
                .Where(t => t.Id.StartsWith("G"))
                .Select(t => t.Nev);
            Console.WriteLine("4-es feladat: " + string.Join("\n", tanarok));

            //
            var bizotsag = db.Vizsgak
                .Select(vb => vb.Bizottsag)
                .Distinct();
            Console.WriteLine("5-ös feladat: " + string.Join("\n", bizotsag));

            //
            var letszam = db.Vizsgazo
                .Select(v => v.Diaknev);
            Console.WriteLine("6-os feladat: " + string.Join("\n", letszam));
        }
    }
   

}
