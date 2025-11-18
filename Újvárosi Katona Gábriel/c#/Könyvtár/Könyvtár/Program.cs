using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvtár
{

 

    internal class Program
    {
        static void Main(string[] args)
        {


     // StreamReader be = new StreamReader("konyvek.txt");

         //   while (!be.EndOfStream)
         //   {

        //    }
            List<string> list = new List<string>(File.ReadAllLines("konyvek.txt"));
            List<Konyv> konyvek = new List<Konyv>();
            List<string>  resz = new List<string>();
            foreach (string line in list) {
                string[] split = line.Split(';');
                konyvek.Add(new Konyv(split[0], int.Parse(split[1]), int.Parse(split[2]), split[3]));
                if (!resz.Contains(split[3]))
                {
                    resz.Add(split[3]);
                }
            }
            resz.Sort();
            konyvek.Sort();


         
          

            Dictionary<string, List<Konyv>> Reszlegek = new Dictionary<string, List<Konyv>>();
            foreach (string line in resz) { 
            
               if (!Reszlegek.ContainsKey(line))
                {
                    Reszlegek.Add(line, new List<Konyv>());
                }
            
            }
            foreach (Konyv konyv in konyvek)
            {

                Reszlegek[konyv.Reszleg].Add(konyv);
            }
/*
            foreach (var reszleg in Reszlegek.Keys)
            {
                var rendezett = Reszlegek[reszleg]
                    .OrderByDescending(k => k.KiadasiEv)
                    .ThenBy(k =>)
            };
*/
            foreach (var item in Reszlegek) { 
                
                item.Value.Sort();
                Console.WriteLine("  " + item.Key + ":");
                foreach (var konyv in item.Value) {
                    Console.WriteLine(konyv.Cim);
                }

            }

            Console.ReadLine();
        }
    }
}
