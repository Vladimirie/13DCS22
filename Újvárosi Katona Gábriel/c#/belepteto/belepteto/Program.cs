using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace belepteto
{
    internal class Program
    {
        class Belepes
        {
            public string StudentCode { get; set; }

            public DateTime Time { get; set; }

            public int EsemenyCode { get; set; }

            public Belepes(string studentCode, DateTime time, int esemenyCode)
            {
                StudentCode = studentCode;
                Time = time;
                EsemenyCode = esemenyCode;
            }
        }

        // 1 es feladat
        static void Main(string[] args)
        {
            

            List<string> Beolvasas = new List<string>(File.ReadLines("bedat.txt"));
            List<Belepes> Belepesek = new List<Belepes>();
            foreach (string line in Beolvasas) {

                string[] split = line.Split(' ');
               

                Belepesek.Add(new Belepes(split[0], DateTime.Parse(split[1]), int.Parse(split[2]) ) );
            }
            // 2 es feladat

            DateTime min = DateTime.MaxValue;
            DateTime max = DateTime.MinValue;

            foreach (Belepes Belepes in Belepesek)
            {
                if (Belepes.Time > max)
                {
                    max = Belepes.Time;
                } 
                if (Belepes.Time < min) {
                    min = Belepes.Time;
                }

            }


            
            Console.WriteLine("2 es feladat");
            Console.WriteLine($"Első tanuló érkezése : {min.ToString("HH:mm")}  ");
            Console.WriteLine($"Utolsó Tanuló távozása : {max.ToString("HH:mm")}  ");
            // 3 mas feladat

      
            Console.WriteLine("3 mas feladat (Néz bele a file ba)");

    
            List<string> write = new List<string>();
            foreach (Belepes belepes in Belepesek)
            {

                if (belepes.Time.Hour * 60 + belepes.Time.Minute > 470  && belepes.Time.Hour * 60 + belepes.Time.Minute < 495 && belepes.EsemenyCode == 1) {
               
                //    Console.WriteLine(belepes.Time.ToString("HH:mm"));
                    write.Add($" {belepes.Time.ToString("HH:mm")} {belepes.StudentCode} ");
                }
            }

            File.WriteAllLines("kesok.txt", write);
           
            // 4 es feladat
            int menzacount = 0;
            foreach (Belepes belepes in Belepesek)
            {
                if (belepes.EsemenyCode == 3) menzacount++;
            }
           
            Console.WriteLine("4 es feladat");
            Console.WriteLine($"A menzán aznap {menzacount} tanuló ebédelt");
            // 5 ös feladat
            int konyvtarcount = 0;
             List<string> konyvtaros = new List<string>();
            

            foreach (Belepes belepes in Belepesek)
            {
                if (belepes.EsemenyCode == 4 && !konyvtaros.Contains(belepes.StudentCode))
                {
                    konyvtarcount++;
                    konyvtaros.Add(belepes.StudentCode);

                }
            }
            Console.WriteLine("5 ös feladat");
            if (konyvtarcount > menzacount) {
                Console.WriteLine("Többenvoltak, mint a menzán.");
            } else
            {
                Console.WriteLine("Nem voltak többen, mint a menzán.");
            }
            // 6 os feladat
               int f = 11 * 60 + 0;
              Console.WriteLine(f);

            List<string> marbelepet = new List<string>();

            foreach (Belepes belepes in Belepesek)
            {
                if (HourtMintoInt(belepes.Time) < 645 && !marbelepet.Contains(belepes.StudentCode) && belepes.EsemenyCode == 1)
                {
                    marbelepet.Add(belepes.StudentCode);

                }
            }
            List<string> legaliskilepes = new List<string>();
            foreach (Belepes belepes in Belepesek)
            {
                if (HourtMintoInt(belepes.Time) > 645 && HourtMintoInt(belepes.Time) < 650 && belepes.EsemenyCode == 2 && !legaliskilepes.Contains(belepes.StudentCode))
                {
                    legaliskilepes.Add(belepes.StudentCode);
                }
            }

            List<string> roszfiunk = new List<string>();
            foreach (Belepes belepes in Belepesek)
            {
                if (HourtMintoInt(belepes.Time) <= 660 && HourtMintoInt(belepes.Time) >= 650 && !legaliskilepes.Contains(belepes.StudentCode) && marbelepet.Contains(belepes.StudentCode) && belepes.EsemenyCode == 1)
                {
                    roszfiunk.Add(belepes.StudentCode);
                }
                
            }
            Console.WriteLine("6 os feladat");

            Console.WriteLine($"Az érintett tanulók: ");
            foreach (string fiu in roszfiunk)
            {
                Console.Write(fiu + " ");
            }
          
                
                Console.ReadLine();

        }


        public static int HourtMintoInt(DateTime dateTime)
        {
            return dateTime.Hour * 60 + dateTime.Minute;
        }
    }
}
