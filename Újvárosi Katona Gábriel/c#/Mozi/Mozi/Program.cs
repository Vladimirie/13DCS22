using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mozi
{


    class Film : IComparable<Film>
    {
        public string FilmCim { get; set; }

        public string Mufaj { get; set; }
        public int Korhatar { get; set; }
        public int KezdesiIdo { get; set; }

        public Film(string filmCim, string mufaj, int korhatar, int kezdesiIdo)
        {
            FilmCim = filmCim;
            Mufaj = mufaj;
            Korhatar = korhatar;
            KezdesiIdo = kezdesiIdo;
        }

        public override string ToString() { 
        
            return $" {this.FilmCim}  ({this.Mufaj}):  {this.KezdesiIdo} ";
        }

        public int CompareTo(Film other)
        {
            if (this.KezdesiIdo == other.KezdesiIdo)
            {
                if (this.Korhatar == other.Korhatar) {
                
                  return  this.FilmCim.CompareTo(other.FilmCim);
                
                }
                else
                {

                    return other.Korhatar.CompareTo(this.Korhatar);
                }
            }  else
            {
                return this.KezdesiIdo.CompareTo(other.KezdesiIdo);
            }

            

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

          
            List<string> bemenet = new List<string>(File.ReadLines("bemenet.csv"));
            List<Film> filmek = new List<Film>();
            int feldolgozando_sorok = int.Parse( bemenet[0]);
            bemenet.RemoveAt(0);
                for (int i = 0; i < feldolgozando_sorok; i++)
            {
                string[] split = bemenet[i].Split(';');
                filmek.Add(new Film(split[0], split[1] , int.Parse(split[2]), int.Parse(split[3])));

            }



            filmek.Sort();
            foreach (Film film in filmek) {

                Console.WriteLine(film.ToString());
            }
         //   File.WriteAllLines("Kimenet.csv", filmek);
            Console.ReadLine();
        }
    }
}
