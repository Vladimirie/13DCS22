using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;





namespace RHAAAAAAAAAA_bash__bash__bash_mozi
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new MoziDbContext();

            /*
                        var de = db.Alkotok.Select(alkat => alkat.Nev ).ToList();
                        Console.WriteLine(string.Join("\n", de));
                        Console.WriteLine(de.Count());
                        //     var ne = db.Filmek.Select(film => film.Cim).ToList();
                         //     Console.WriteLine(string.Join("\n", ne));
            */
            //SELECT `cim` FROM `filmek` WHERE `szines` = "színes"
            var szines = db.Filmek.Where(f => f.Szines == "színes").Select(f => f.Cim);
            Console.WriteLine(string.Join("\n", szines));
            Console.WriteLine( szines.Count());
            var hosz = db.Filmek.Where(f => f.Hossz > 120).OrderBy(f => f.Hossz).Select(f => f.Cim);





        }
    }



}