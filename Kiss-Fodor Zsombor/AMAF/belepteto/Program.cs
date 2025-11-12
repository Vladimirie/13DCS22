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
        }
    }
}
