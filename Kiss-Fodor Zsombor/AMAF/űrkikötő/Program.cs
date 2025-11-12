using System.Reflection;

namespace űrkikötő
{
    internal class Program
    {
        public class Jarmu
        {
            public string Azonosito { get; set; }
            public string Tipus { get; set; }
            public int ErkezesNap { get; set; }

            public Jarmu(string azonosito, string tipus, int erkezesnap)
            {
                Azonosito = azonosito;
                Tipus = tipus;
                ErkezesNap = erkezesnap;
            }

            public override string ToString()
            {
                return $"{Azonosito} {Tipus}";
            }
        }

        static void Main(string[] args)
        {
            List<Jarmu> jarmuvek = new List<Jarmu>();
            HashSet<string> tipusok = new HashSet<string>();
            Dictionary<string, int> erkezettTipusSzamok = new Dictionary<string, int>();

            string[] informaciok = File.ReadAllLines("jarmuvek.csv");
            string[] informaciokCut = informaciok.Skip(1).ToArray();

            foreach (string jargany in informaciokCut)
            {
                string[] s = jargany.Split(";");

                if (!tipusok.Contains(s[1]))
                {
                    tipusok.Add(s[1]);
                }

                if (erkezettTipusSzamok.ContainsKey(s[1]))
                {
                    erkezettTipusSzamok[s[1]]++;
                }
                else
                {
                    erkezettTipusSzamok.Add(s[1], 1);
                }

                jarmuvek.Add(new Jarmu(s[0], s[1], int.Parse(s[2])));
            }

            Console.WriteLine("//3. feladat");
            Console.WriteLine(NapKeres(jarmuvek));
            Console.WriteLine(TipusKeres(jarmuvek));
            
            Dictionary<int, List<Jarmu>> napikocsik = new Dictionary<int, List<Jarmu>>();
            foreach (Jarmu kocsi in jarmuvek)
            {
                if (napikocsik.ContainsKey(kocsi.ErkezesNap))
                {
                    napikocsik[kocsi.ErkezesNap].Add(kocsi);
                }
                else
                {
                    napikocsik.Add(kocsi.ErkezesNap, new List<Jarmu>());
                    napikocsik[kocsi.ErkezesNap].Add(kocsi);
                }
            }

            ErkezesKiir(napikocsik);
            Console.WriteLine("//4. feladat");
            Console.Write("Kérem írjon be egy napot: ");
            string nap = Console.ReadLine();
            NapiAdatok(nap, napikocsik);
        }

        static string NapKeres(List<Jarmu> nap)
        {
            Dictionary < int, int> kocsik = new Dictionary< int, int>();
            foreach (Jarmu jarmu in nap)
            {
                if (kocsik.ContainsKey(jarmu.ErkezesNap))
                {
                    kocsik[jarmu.ErkezesNap]++;
                }
                else
                {
                    kocsik.Add(jarmu.ErkezesNap, 1);
                }
            }

            int maxi = kocsik.ElementAt(0).Value;
            int maxistringidfkmanIamtiredofthishit = kocsik.ElementAt(0).Key;
            for (int i = 0; i < kocsik.Count; i++)
            {
                if (kocsik.ElementAt(i).Value > maxi)
                {
                    maxi = kocsik.ElementAt(i).Value;
                    maxistringidfkmanIamtiredofthishit = kocsik.ElementAt(i).Key;
                }
            }

            return $"A(z) {maxistringidfkmanIamtiredofthishit}. napon érkezett a legtöbb jármű ({maxi})";
        }

        static string TipusKeres(List<Jarmu> kocsik)
        {
            Dictionary<string, int> ranglista = new Dictionary<string, int>();
            foreach (Jarmu jarmu in kocsik)
            {
                if (ranglista.ContainsKey(jarmu.Tipus))
                {
                    ranglista[jarmu.Tipus]++;
                }
                else
                {
                    ranglista.Add(jarmu.Tipus, 1);
                }
            }

            int maxi = ranglista.ElementAt(0).Value;
            string maxistringidfkmanIamtiredofthishit = ranglista.ElementAt(0).Key;
            for (int i = 0; i < ranglista.Count; i++)
            {
                if (ranglista.ElementAt(i).Value > maxi)
                {
                    maxi = ranglista.ElementAt(i).Value;
                    maxistringidfkmanIamtiredofthishit = ranglista.ElementAt(i).Key;
                }
            }

            return $"A(z) {maxistringidfkmanIamtiredofthishit} típusból érkezett be a legtöbb. ({maxi})";
        }

        static void ErkezesKiir(Dictionary<int, List<Jarmu>> kocsik)
        {          
            for (int i = 0; i < kocsik.Count; i++)
            {
                
                Console.WriteLine($" A(z) {kocsik.ElementAt(i).Key}. napon {kocsik.ElementAt(i).Value.Count} jármű érkezett");
            }
        }

        static void NapiAdatok(string napKeress, Dictionary<int, List<Jarmu>> kocsik)
        {
            if (kocsik.ContainsKey(int.Parse(napKeress))) 
            {
                Dictionary<string, int> tipusDarab = new Dictionary<string, int>();
                foreach (Jarmu car in kocsik[int.Parse(napKeress)])
                {
                    Console.WriteLine(car);
                    if (tipusDarab.ContainsKey(car.Tipus))
                    {
                        tipusDarab[car.Tipus]++;
                    }
                    else
                    {
                        tipusDarab.Add(car.Tipus, 1);
                    }
                }

                for (int i = 0; i < tipusDarab.Count; i++)
                {
                    Console.WriteLine($"{tipusDarab.ElementAt(i).Key} {tipusDarab.ElementAt(i).Value}");
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen nap a listában!");
            }
        }
    }
}