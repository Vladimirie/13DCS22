using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Schema;

namespace Galaktikus
{
    internal class Program
    {


        class Kolonia
        {
            public string Azonosito { get; set; }
            public string Nev { get; set; }
            public string Szektor { get; set; }

             public string toString()
            {
                return $"Azonosító: {Azonosito} Név: {Nev} Szektor: {Szektor}";
            }
            public Kolonia(string azonosito, string nev, string szektor)
            {
                Azonosito = azonosito;
                Nev = nev;
                Szektor = szektor;
            }
        }

        

            class Szallitas
        {
            public Kolonia Forras { get; set; }
            public Kolonia Cel { get; set; }
            public int Menyiseg { get; set; }

            public string toString()
            {
                return $" Forrás: {Forras.Nev} Cél: {Cel.Nev} Menyiség: {Menyiseg}";
            }
            public Szallitas(Kolonia forras, Kolonia cel, int menyiseg)
            {
                Forras = forras;
                Cel = cel;
                Menyiseg = menyiseg;
            }
        }
            static void Main(string[] args)
        {

            List<Kolonia> Kolonies = new List<Kolonia>();

            string[] Kolonyread = File.ReadAllLines("kolonia.csv");
            
            


            foreach (string line in Kolonyread) {

                string[] split = line.Split(';');

                Kolonies.Add(new Kolonia(split[0], split[1], split[2]));

                
            }
            Dictionary<string, Kolonia> Kolonidictionery = new Dictionary<string, Kolonia>();

            foreach (Kolonia kolonia1 in Kolonies) {
                Kolonidictionery.Add(kolonia1.Azonosito, kolonia1);
            }
            
            List<Szallitas> Szalitasok = new List<Szallitas>();
            string[] szalitasread = File.ReadAllLines("szallitasok.csv");
            foreach (string line in szalitasread)
            {
                string[] split = line.Split(';');




                Szalitasok.Add(new Szallitas(Kolonidictionery[split[0]], Kolonidictionery[split[1]], int.Parse(split[2]) ));
                
            }


            foreach (Kolonia kolonia in Kolonies)
            {
                int db = 0;
                foreach (Szallitas szallitas in Szalitasok) { 
                if (szallitas.Cel.Azonosito == kolonia.Azonosito || szallitas.Forras.Azonosito == kolonia.Azonosito)
                    {

                    db++; }
                
                
                }

                Console.WriteLine($"A(z) {kolonia.Nev}: {db} Szálitásban vett részt.");

            }


            int maxszalitot = 0;
            string maxcolony = "";

            foreach (Kolonia kolonia in Kolonies)
            {
                int szalitasok = 0;

                foreach (Szallitas szallitas in Szalitasok)
                {
                    if (szallitas.Cel.Azonosito == kolonia.Azonosito || szallitas.Forras.Azonosito == kolonia.Azonosito)
                    {
                        szalitasok += szallitas.Menyiseg;

                    }


                }
                if (maxszalitot < szalitasok)
                {
                    maxszalitot = szalitasok;
                    maxcolony = kolonia.Azonosito;
                }

            }



            Console.WriteLine($" legforgalmasabb kolónia: {Kolonidictionery[maxcolony].Nev}");
            
         Dictionary<string, int> sectordb = new Dictionary<string, int>();
            Dictionary<string, int> sectorSum = new Dictionary<string, int>();   
            

            foreach (Szallitas szallitas1 in Szalitasok)
            {
                if (!sectordb.ContainsKey(szallitas1.Forras.Szektor))
                {
                    sectordb.Add(szallitas1.Forras.Szektor, 0);
                    sectorSum.Add(szallitas1.Forras.Szektor, 0);
                }
                if (!sectordb.ContainsKey(szallitas1.Cel.Szektor))
                {
                    sectordb.Add(szallitas1.Cel.Szektor, 0);
                    sectorSum.Add(szallitas1.Cel.Szektor, 0);
                }

                if (sectordb[szallitas1.Forras.Szektor] == sectordb[szallitas1.Cel.Szektor])
                {
                    sectordb[szallitas1.Forras.Szektor]++;
                    sectorSum[szallitas1.Forras.Szektor] += szallitas1.Menyiseg;
                }
                else {

                    sectordb[szallitas1.Forras.Szektor]++;
                    sectorSum[szallitas1.Forras.Szektor] += szallitas1.Menyiseg;
                    sectordb[szallitas1.Cel.Szektor]++;
                    sectorSum[szallitas1.Cel.Szektor] += szallitas1.Menyiseg;
                }

              
                

       




            }


            foreach (var item in sectordb)
            {
                Console.WriteLine($"A(z) {item.Key} sectorban összesen: {item.Value} Szálítás történt és az összes árumenyiség:{sectorSum[item.Key]} Tonna.");



            }
            


                Console.ReadLine();

        }
    }
}
