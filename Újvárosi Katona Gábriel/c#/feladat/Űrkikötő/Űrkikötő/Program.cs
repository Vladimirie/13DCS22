using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Űrkikötő
{
    // 1 es feladat
    class Jarmu
    {
        public string Azonosito { get; set; }
        public string Tipus { get; set; }

        public int EkrezesNap { get; set; }

        public string toString()
        {
            return $"Azonosító: {Azonosito} Tipus: {Tipus} Érkezés Napja: {EkrezesNap}";
        }

        public Jarmu(string azonosito, string tipus, int ekrezesNap)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            EkrezesNap = ekrezesNap;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            // 2 es feldadat
            List<Jarmu> Jarmuvek = new List<Jarmu>();
            HashSet<string> JarmuHash = new HashSet<string>();
            Dictionary<string, int> TipusCountDc = new Dictionary<string, int>();
            string[] beolvasas = File.ReadAllLines("jarmuvek.csv");


            bool skipfirst = false;
            foreach (string line in beolvasas)
            {
                if (skipfirst)
                {
                    string[] split = line.Split(';');


                    Jarmuvek.Add(new Jarmu(split[0], split[1], int.Parse(split[2])));

                    if (!JarmuHash.Contains(split[1]))
                    {
                        JarmuHash.Add(split[1]);
                    }
                    if (!TipusCountDc.ContainsKey(split[1]))
                    {
                        TipusCountDc.Add(split[1], 1);
                    }
                    else
                    {
                        TipusCountDc[split[1]]++;

                    }




                }
                else
                {
                    skipfirst = true;
                }

            }


            // 3 mas feladat

            Napkeres(Jarmuvek);
            LegtobbJarmutipuss(TipusCountDc);
            Dictionary<int, List<Jarmu>> erkezesNapJarmuD = JamruErkezesRendez(Jarmuvek);


            // 4 es feladat

            Console.WriteLine("Kérek egy napott!");
            int bekertnap = int.Parse(Console.ReadLine());

            if (erkezesNapJarmuD.ContainsKey(bekertnap))
            {
                Dictionary<string, int> megegytipuscont = new Dictionary<string, int>();
                foreach (Jarmu kicsikocsi in erkezesNapJarmuD[bekertnap])
                {

                    Console.WriteLine(kicsikocsi.toString());
                    if (!megegytipuscont.ContainsKey(kicsikocsi.Tipus))
                    {
                        megegytipuscont.Add(kicsikocsi.Tipus, 1);
                    }
                    else
                    {
                        megegytipuscont[kicsikocsi.Tipus]++;

                    }
                }
                Console.WriteLine("Ezen a napon az az adotot tipusokból enyi volt:");

                foreach (var tipcount in megegytipuscont)
                {
                    Console.WriteLine($"Tipus: {tipcount.Key} Megyiség: {tipcount.Value}");
                }




            }
            else
            {
                Console.WriteLine("Ilyen nap nics.");
            }




            Console.ReadLine();
        }

        public static void Napkeres(List<Jarmu> Jarmuvek)
        {
            Dictionary<int, int> NapCount = new Dictionary<int, int>();
            foreach (Jarmu jarmu in Jarmuvek)
            {
                if (!NapCount.ContainsKey(jarmu.EkrezesNap))
                {
                    NapCount.Add(jarmu.EkrezesNap, 1);
                }
                else
                {
                    NapCount[jarmu.EkrezesNap]++;


                }
            }

            int maxval = NapCount[1];
            int maxkey = NapCount[1];
            foreach (var Nap in NapCount)
            {
                if (Nap.Value > maxval)
                {
                    maxval = Nap.Value;
                    maxkey = Nap.Key;
                }


            }

            Console.WriteLine($" A {maxkey} napon ékrezet a legtöbb jármű :{maxval}  ");

        }

        public static void LegtobbJarmutipuss(Dictionary<string, int> Jarmutipusok)
        {
            string maxkey = "";
            int maxval = 0;
            foreach (var Tipus in Jarmutipusok)
            {
                if (Tipus.Value > maxval)
                {
                    maxval = Tipus.Value;
                    maxkey = Tipus.Key;
                }
            }

            Console.WriteLine($"A {maxkey} Tipusból érkezet a lebtöbb: {maxval}");
        }
        public static Dictionary<int, List<Jarmu>> JamruErkezesRendez(List<Jarmu> Jarmuvek)
        {
            Dictionary<int, List<Jarmu>> erkezesNapJarmuD = new Dictionary<int, List<Jarmu>>();

            foreach (Jarmu Jarmu in Jarmuvek)
            {
                if (!erkezesNapJarmuD.ContainsKey(Jarmu.EkrezesNap))
                {
                    List<Jarmu> Jarmuvek2 = new List<Jarmu>();
                    Jarmuvek2.Add(Jarmu);
                    erkezesNapJarmuD.Add(Jarmu.EkrezesNap, Jarmuvek2);

                }
                else
                {

                    erkezesNapJarmuD[Jarmu.EkrezesNap].Add(Jarmu);
                }
            }

            Console.WriteLine($"{erkezesNapJarmuD.Count} különböző napra érkezet jármű");

            

            foreach (var Nap in erkezesNapJarmuD)
            {
                // A feladat nem mongya hogy mien sorrendbe legyenek a napok :)
                Console.WriteLine($"Nap:{Nap.Key} Járvűvek: {Nap.Value.Count} ");
            }

            return erkezesNapJarmuD;
        }
    }
}
