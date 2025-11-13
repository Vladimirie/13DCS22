namespace mozi_mozi_lady
{
    internal class Program
    {

        class Film: IComparable<Film>
        {
            public string Cim { get; set; }
            public string Mufaj { get; set; }
            public int Korhatar { get; set; }
            public int KezdesiPerc { get; set; }

            public Film(string cim, string mufaj, int korhatar, int kezdesiPerc)
            {
                Cim = cim;
                Mufaj = mufaj;
                Korhatar = korhatar;
                KezdesiPerc = kezdesiPerc;
            }

            public override string ToString()
            {
                return $"{Cim} ({Mufaj}): {KezdesiPerc}";
            }

            public int CompareTo(Film? other)
            {
                //csökkenő sorrend
                if (other.KezdesiPerc.CompareTo(this.KezdesiPerc) == 0)
                {
                    if (other.Korhatar.CompareTo(this.Korhatar) == 0)
                    {
                        return this.Cim.CompareTo(other.Cim);
                    }
                    else
                    {
                        return this.Cim.CompareTo(other.Cim);
                    }
                }
                else
                {
                    return this.KezdesiPerc.CompareTo(other.KezdesiPerc);
                }
            }

        }

        static void Main(string[] args)
        {
            List<Film> filmLista = new List<Film>();
            string[] file = File.ReadAllLines("bemenet.csv");
            int maxszam = int.Parse(file[0]);

            for (int i = 1; i < file.Length; i++)
            {
                string[] split = file[i].Split(";");
                filmLista.Add(new Film(split[0], split[1], int.Parse(split[2]), int.Parse(split[3])));
            }

            int n = 5;
            List<Film> inputFilmlista = new List<Film>();

            for (int i = 0; i < n; i++)
            {
                inputFilmlista.Add(filmLista[i]);
            }

            inputFilmlista.Sort();

            for (int i = 0; i < inputFilmlista.Count(); i++)
            {
                Console.WriteLine(inputFilmlista[i]);
            }
        }
    }
}
