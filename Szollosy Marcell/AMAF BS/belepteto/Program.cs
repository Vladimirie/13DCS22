namespace belepteto
{
    internal class Program
    {
        class TanuloEvent
        {
            public string ID { get; set; }
            public string Ido { get; set; }
            public int EsemenyKod { get; set; }

            public TanuloEvent(string id, string ido, int esemenyKod)
            {
                ID = id;
                Ido = ido;
                EsemenyKod = esemenyKod;
            }

            public override string ToString()
            {
                return $"{ID} {Ido} {EsemenyKod}";
            }
        }


        static void Main(string[] args)
        {
            //1. feladat
            List<TanuloEvent> tanuloInfo = new List<TanuloEvent>();
            string[] file = File.ReadAllLines("bedat.txt");

            foreach (var line in file )
            {
                string[] token = line.Split(" ");
                tanuloInfo.Add(new TanuloEvent(token[0], token[1], int.Parse(token[2])));
            }

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"Az első tanuló {tanuloInfo[0].Ido}-kor lépett be a főkapun.");
            Console.WriteLine($"Az utolsó tanuló {tanuloInfo.Last().Ido}-kor lépett ki a főkapun.");

            //4. feladat
            Console.WriteLine("4. feladat");
            int menza = (from b in tanuloInfo where b.EsemenyKod == 3 select b).Count();
            Console.WriteLine($"A menzán aznap {menza} tanuló ebédelt.");

            //5. feladat
            Console.WriteLine("5. feladat");
            HashSet<string> kolcsonzesek = new HashSet<string>();
            foreach (var tag in tanuloInfo)
            {
                if (tag.EsemenyKod == 4)
                {
                    kolcsonzesek.Add(tag.ID);
                }
            }

            Console.WriteLine($"Aznap {kolcsonzesek.Count} tanuló kölcsönzött a könyvtárban.");
            if (kolcsonzesek.Count > menza)
            {
                Console.WriteLine("Többen voltak, mint a menzán.");
            }
            else
            {
                Console.WriteLine("Nem voltak többen, mint a menzán.");
            }

            //6.
            HashSet<string> bejelentkezo = new HashSet<string>();
            HashSet<string> kijelentkezo = new HashSet<string>();
            foreach (TanuloEvent diak in tanuloInfo)
            {
                DateTime ido = DateTime.ParseExact(diak.Ido, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                //Console.WriteLine(ido.ToString("HH:mm", System.Globalization.CultureInfo.CurrentCulture));           

                if (ido < DateTime.ParseExact("10:45", "HH:mm", 
                    System.Globalization.CultureInfo.CurrentCulture) 
                    && diak.EsemenyKod == 1)
                {
                    bejelentkezo.Add(diak.ID);
                }
                else if (ido < DateTime.ParseExact("11:00", "HH:mm", 
                    System.Globalization.CultureInfo.CurrentCulture) 
                    && diak.EsemenyKod == 2)
                {
                    kijelentkezo.Add(diak.ID);
                }
            }

            HashSet<string> dudeidkhelpme = new HashSet<string>();
            foreach (string ID in bejelentkezo)
            {
                if (!kijelentkezo.Contains(ID))
                {
                    dudeidkhelpme.Add(ID);
                }
            }

            foreach (TanuloEvent diak in tanuloInfo)
            {
                DateTime ido = DateTime.ParseExact(diak.Ido, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                if (ido > DateTime.ParseExact("10:45", "HH:mm", 
                    System.Globalization.CultureInfo.CurrentCulture) 
                    && diak.EsemenyKod == 1)
                {
                    if (ido < DateTime.ParseExact("11:00", "HH:mm", System.Globalization.CultureInfo.CurrentCulture) 
                        && diak.EsemenyKod == 1)
                    {
                        if (dudeidkhelpme.Contains(diak.ID))
                        {
                            Console.Write($"{diak.ID} ");
                        }
                    }
                }
            }


        }
    }
}