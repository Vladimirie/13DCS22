using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HegyekMo
{
    public class Hegy
    {
        public string name { get; set; }
        public string hegyseg { get; set; }
        public int magasag { get; set; }

        public Hegy(string name, string hegyseg, int magasag) { 
        
            this.name = name;
            this.hegyseg = hegyseg;
            this.magasag = magasag;


        }

    }
    class Program
    {
        static void Main(string[] args)
        {


            List<Hegy> Hegyek = new  List<Hegy>();
            bool skipd_first = false;
            string[] alllines = File.ReadAllLines("hegyekMo.txt");


            foreach (string line in alllines) { 
            
          
                if (skipd_first)
                {
                    string[] split = line.Split(';');
                    string split0 = split[0];
                    string split1 = split[1];
                    int split2 = int.Parse(split[2]);

                   Hegyek.Add(new Hegy(split0, split1, split2));  


                } else
                {
                    skipd_first = true;
                }


            
            }


            Console.WriteLine($"{Hegyek.Count()} Darab hegy található az álományban. ");
            Console.WriteLine($"Hegyek átlagmagasága: {Hegyatlagmagasag(Hegyek)}");
            Console.WriteLine(MaxHegyMagasag(Hegyek));
            Console.WriteLine("Magaságot!");
            int be = int.Parse(Console.ReadLine());

            if (Magasabbvan(Hegyek, be)){
                Console.WriteLine($"van {be} nél magasabb hegy. ");

                 
            }else
            {
                Console.WriteLine($"nincs {be} nél magasabb");
            }


            Console.ReadLine();





        }

        public static double Hegyatlagmagasag(List<Hegy> Hegyek)
        {
            double atlag;
            double sum = 0;



            foreach (Hegy Hegy in Hegyek)
            {

                sum += Hegy.magasag;
            }

            atlag = (sum / Hegyek.Count);
            return atlag;


        }
        public static string MaxHegyMagasag(List<Hegy> Hegyek)
        {
          int max = Hegyek[0].magasag;
            int hegyindex = 0;
            int indexindex = 0;
          foreach (Hegy Hegy in Hegyek)
            {
                if (Hegy.magasag > max)
                {
                    max = Hegy.magasag;
                    hegyindex = indexindex;
                }
                indexindex++;

            }
            return $"A legmagasabb hegy a {Hegyek[hegyindex].name} a {Hegyek[hegyindex].hegyseg} hegységben és {Hegyek[hegyindex].magasag} Púzó magas";

        }
        
        public static bool Magasabbvan(List<Hegy> Hegyek, int beadotertek)
        {
            bool found = false;
            int index = 0;
            while (!found && index < Hegyek.Count())
            {
                if (beadotertek < Hegyek[index].magasag)
                {
                    found = true;
                }

                index++;
            }

            return found;

        }

        



    }

}
