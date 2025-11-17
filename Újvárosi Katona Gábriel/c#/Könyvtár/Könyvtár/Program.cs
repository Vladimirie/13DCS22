using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvtár
{

    class Konyv : IComparable<Konyv>
    {
        public string Cim { get; set; }
        public  int Oldalszal { get; set; }
        public int KiadasiEv { get; set; }
        public  string Reszleg { get; set; }

        public Konyv(string cim, int oldalszal, int kiadasiEv, string reszleg)
        {
            Cim = cim;
            Oldalszal = oldalszal;
            KiadasiEv = kiadasiEv;
            Reszleg = reszleg;
        }

       

        public int CompareTo(Konyv other)
        {
            if (this.KiadasiEv != other.KiadasiEv)
            {
                return other.KiadasiEv.CompareTo(this.KiadasiEv);
            }
           else if (this.Oldalszal != other.Oldalszal) { 
              return  this.Oldalszal.CompareTo(other.Oldalszal);
            }
           else {
            
               return this.Cim.CompareTo(other.Cim);
            }

        }
    }

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
            foreach (string line in list) {
                string[] split = line.Split(';');
                konyvek.Add(new Konyv(split[0], int.Parse(split[1]), int.Parse(split[2]), split[3]));
                
            }

            konyvek.Sort();

            //Dictionery ? maybe
            Dictionary<string, List<Konyv>> Reszlegek = new Dictionary<string, List<Konyv>>();
            foreach (Konyv konyv in konyvek)
            {
                if (!Reszlegek.ContainsKey(konyv.Reszleg))
                {
                    Reszlegek.Add(konyv.Reszleg, new List<Konyv>());
                }
                Reszlegek[konyv.Reszleg].Add(konyv);
            }

            foreach (var item in Reszlegek) { 
                
                item.Value.Sort();
                Console.WriteLine(item.Key + ":");
                foreach (var konyv in item.Value) {
                    Console.WriteLine(konyv.Cim);
                }

            }

            Console.ReadLine();
        }
    }
}
