using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvtár
{

    class Konyv
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>(File.ReadAllLines("konyvek.txt"));
            List<Konyv> konyvek = new List<Konyv>();
            foreach (string line in list) {
                string[] split = line.Split(';');
                konyvek.Add(new Konyv(split[0], int.Parse(split[1]), int.Parse(split[2]), split[3]));
                
            }

            konyvek.Sort();

            //Dictionery ? maybe



        }
    }
}
