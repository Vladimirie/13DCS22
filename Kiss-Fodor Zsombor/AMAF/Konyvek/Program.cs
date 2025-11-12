namespace Konyvek
{
    internal class Program
    {

        class Konyv
        {
            public int KiadasEv { get; set; }
            public int KiadasNegyedEv { get; set; }
            public string Eredete { get; set; }
            public string Leiras { get; set; }
            public int Peldanyszam { get; set; }

            public Konyv(int ev, int negyed, string eredet, string leiras, int peldany)
            {
                KiadasEv = ev;
                KiadasNegyedEv = negyed;
                Eredete = eredet;
                Leiras = leiras;
                Peldanyszam = peldany;
            }
        }


        static void Main(string[] args)
        {
            List<Konyv> konyvek = new List<Konyv>();
            foreach (string line in File.ReadAllLines("kiadas.txt"))
            {
                string[] s = line.Split(";");
                konyvek.Add(new Konyv(int.Parse(s[0]), int.Parse(s[1]), s[2], s[3], int.Parse(s[4])));
            }

            //2. feladat
            Console.WriteLine("2. feladat:");
            Console.Write("Szerző: ");
            string szerzo = Console.ReadLine();
            int kiadas = 0;
            foreach (Konyv konyve in konyvek)
            {   
                if (konyve.Leiras.Contains(szerzo))
                {
                    kiadas++;
                }
            }
            if (kiadas != 0) 
            {
                Console.WriteLine($"könyvkiadás {kiadas}");
            }
            else
            {
                Console.WriteLine("Nem adtak ki");
            }

            //3. feladat
            Console.WriteLine("3. feladat:");
            int max = konyvek[0].Peldanyszam;
            foreach (Konyv maxfind in konyvek)
            {
                if (max < maxfind.Peldanyszam)
                {
                    max = maxfind.Peldanyszam;
                }
            }
            int cases = 0;
            foreach (Konyv idk in konyvek)
            {
                if (idk.Peldanyszam == max)
                {
                    cases++;
                }
            }
            Console.WriteLine($"Legnagyobb példányszám: {max}, előfordult {cases} alkalommal");

            //4. feladat
            Console.WriteLine("4. feladat:");
            bool foundIt = false;
            int i = 0;
            while (i != konyvek.Count() && !foundIt)
            {
                if (konyvek[i].Eredete == "kf" && konyvek[i].Peldanyszam >= 40000)
                {
                    Console.WriteLine($"{konyvek[i].KiadasEv}/{konyvek[i].KiadasNegyedEv}. {konyvek[i].Leiras}");
                    foundIt = true;
                }
                else
                {
                    i++;
                }
            }


            //5. feladat
            Console.WriteLine("5. feladat:");



            //6. feladat
            Console.WriteLine("6. feladat:");


        }
    }
}
