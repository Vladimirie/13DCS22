using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARVEL_RIVELS__REAL_
{
    internal class Program
    {
        static void Main(string[] args)
        {



            List<Jelenet> Jelenetek = new List<Jelenet>();

            string file = "karakterek.txt";
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] firt_split = sr.ReadLine().Split(';');
                        string[] split = firt_split[1].Split(':');
                        string[] heros = split[1].Split(',');

                        

                        Jelenetek.Add(new Jelenet(firt_split[0], int.Parse( split[0]), heros));

                     
                    }
                }
            }

           SortedDictionary<string, int> HeroCount = new SortedDictionary<string, int>();

            Dictionary<string,  HashSet<string>> moviheroc = new Dictionary<string, HashSet<string>>();
            foreach (Jelenet jelenet in Jelenetek) { 
                        
                if (!moviheroc.ContainsKey(jelenet.Film))
                {
                    
                    moviheroc.Add(jelenet.Film, new HashSet<string>());

                }
                foreach (string hero in jelenet.Heros)
                {
                    if (!moviheroc[jelenet.Film].Contains(hero))
                    {
                        moviheroc[jelenet.Film].Add(hero);
                    }
                }


            }

            /*
            foreach (var f in moviheroc)
            {
                Console.WriteLine(f.Key);
                foreach (string g in f.Value)
                {
                    Console.WriteLine("  " + g);
                }
            }

            */
            foreach (var film in moviheroc) { 
                    
              
                foreach (string hero in film.Value) {
                    if (!HeroCount.ContainsKey(hero))
                    {
                        HeroCount.Add(hero, 0);
                     

                    }
                   
                    HeroCount[hero]++;
                }

            }

            /*
            foreach(Film film in filmek)
            {

               List<string> listf = new List<string>();
                if (!moviheroc.ContainsKey(film.Cim)) moviheroc.Add(film.Cim  , listf);
                
                foreach (string hero in film.Heros) {
                     
                     

                    if (!HeroCount.ContainsKey(hero))
                    {
                        HeroCount.Add(hero, 0);
                    }
                    HeroCount[hero]++;
                        }
            }
            */
            foreach (KeyValuePair<string, int> hero in HeroCount) { 
                    
                if (hero.Value >= 2)
                {
                    Console.WriteLine($"{hero.Key}: {hero.Value}");
                }
            
            }

            Console.ReadLine();

        }
    }
}
