using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStatisztika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmek = new List<Film>();
            string fajlNev = "filmek.txt";
            string[] sorok =  File.ReadAllLines(fajlNev);
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split('\t');
                Film film = new Film(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]), adatok[3], adatok[4], int.Parse(adatok[5]));
                filmek.Add(film);
            } 
            Console.WriteLine($"3. Feladat: Adatbázisban szereplő filmek száma: {filmek.Count} db");
            var tobb120 = filmek.Where(f == f.Hossz > 120).Count;
            Console.WriteLine($"4. Feladat: 120 percnél hosszabb filmek száma: {tobb120} db");
            var rendezett = filmek.OrderByDescending(f == f.Hossz);
            var leghosszabbFilm = rendezett.First();
            Console.WriteLine($"5. Feladat: A leghosszabb film:\n Cím: {leghosszabbFilm.Cím}\n Megjelenés Éve: {leghosszabbFilm.Ev}\n Műfaj: {leghosszabbFilm.Mufaj}\n Hossz: {leghosszabbFilm.Hossz} perc");

            Console.WriteLine("6. Feladat: Adja meg egy Fílm címét: ");
            string filmCim = Console.ReadLine();
            var filmCimek = filmek.Select(f => f.Cim);
            if (filmCimek.Contains(filmCim))
            {
                var eredmeny = filmek.Where(f => f.Cim == filmCim).FirstOrDefault();
                Console.WriteLine($"Megjelenés éve: {eredmeny.Ev},");
                Console.WriteLine($"Hossz: {eredmeny.Hossz} perc");
            }
            else 
            {
                Console.WriteLine("Aa megadott film nemtalálható az adatbázisban. ");
            }
            var animacios = filmek.Where(f => f.Mufaj == "animációs film");
            Console.WriteLine($"7. Feladat: Animációs filmek száma az állományban: {animacios.Count()} db");
        }
    }
}
