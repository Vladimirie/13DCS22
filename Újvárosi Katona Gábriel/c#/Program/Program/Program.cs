using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {



            /*
            Dictionary<string, string> Countrysies = new Dictionary<string, string>();

            Countrysies.Add("USA", "Washington, FFF, AAAA");
            Countrysies.Add("England", "LONdon");


            if (Countrysies.ContainsKey("USA")){

                Console.WriteLine(Countrysies["USA"]);

            }
            */

            string bekertszo = Console.ReadLine().ToLower();
            Dictionary<char, int> betuszamok = new Dictionary<char, int>();

            foreach (char betu in bekertszo)
            {
                if (char.IsLetter(betu)){
                if (betuszamok.ContainsKey(betu))
                {

                    betuszamok[betu]++;


                }
                else
                {
                    betuszamok.Add(betu, 1);
                }

               }
            }

            Console.WriteLine("A szőban található betűk:");
            foreach (var betu in betuszamok) { 
            
                    Console.WriteLine(betu.Key + " = " + betu.Value);
            
            }

                 Console.ReadLine();



        }
    }
}
