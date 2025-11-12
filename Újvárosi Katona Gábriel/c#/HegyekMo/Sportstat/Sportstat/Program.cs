using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportstat
{
    internal class Program
    {

        class Jatekos : IComparable<Jatekos>
        {
            public string Nev { get; set; }
            public string Post { get; set; }

            public int Golok { get; set; }

            public Jatekos(string nev, string post, int golok)
            {
                Nev = nev;
                Post = post;
                Golok = golok;
            }

            public int CompareTo(Jatekos other)
            {
                // csökenő sorrend
          //     return other.Golok.CompareTo(this.Golok);

                // növekvő sorend golszám szering
                if (this.Golok.CompareTo(other.Golok) == 0)
                {
                    return this.Nev.CompareTo(other.Nev);
                } else
                {
                    return this.Golok.CompareTo(other.Golok);
                } 

               



            }
        }

        static void Main(string[] args)
        {


            List<Jatekos> jatekosok = new List<Jatekos>();

            jatekosok.Add(new Jatekos("Nagy Bence", "kapus", 5 ));
            jatekosok.Add(new Jatekos("Puskás Ronaldo", "Támadó", 420));
            jatekosok.Add(new Jatekos(" Gyükér Eugin", "Közép Pályás", 0));
            jatekosok.Add(new Jatekos("Urban Viktor", "Hátvéd", 69));
            jatekosok.Add(new Jatekos("Pisztojos Ferenc", "Hátvéd", 30));
            jatekosok.Add(new Jatekos("Szabó Gergő", "Kapus", 30));


            jatekosok[2].Golok += 5;
            Console.WriteLine($"Játékos neve: {jatekosok[2].Nev} Játékos postja: {jatekosok[2].Post} Játékos Goljainak száma: {jatekosok[2].Golok} ");


            jatekosok.Sort();

            foreach (Jatekos jatekos in jatekosok) Console.WriteLine(jatekos.Nev + jatekos.Golok);


            jatekosok.Remove(jatekosok[0]);

         
            int theid = jatekosok.Count() -1;


            Console.WriteLine("A legtöbb golt szerző játékos:" +  jatekosok[theid].Nev + " " + jatekosok[theid].Golok);

            Stack<Jatekos> aVerem = new Stack<Jatekos>();

            aVerem.Push(jatekosok[0]);
            aVerem.Push(jatekosok[1]);
            aVerem.Push(jatekosok[2]);

            foreach(Jatekos aldozat in aVerem)
            {
                Console.WriteLine(aldozat.Nev);
            }
            
            
            Console.ReadLine();
        }
    }
}
