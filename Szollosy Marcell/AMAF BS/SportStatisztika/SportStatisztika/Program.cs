namespace futbal
{
    internal class Program
    {
        class Jatekos : IComparable<Jatekos>
        {
            public string Nev { get; set; }
            public string Post { get; set; }
            public int Gol { get; set; }

            public Jatekos(string nev, string post, int gol)
            {
                Nev = nev;
                Post = post;
                Gol = gol;
            }

            public int CompareTo(Jatekos? other)
            {
                //csökkenő sorrend
                if (other.Gol.CompareTo(this.Gol) == 0)
                {
                    return this.Nev.CompareTo(other.Nev);
                }
                else
                {
                    return other.Gol.CompareTo(this.Gol);
                }
            }

            public override string ToString()
            {
                return $"Játékos neve: {Nev}, pályája: {Post} és gólszáma: {Gol}";
            }
        }

        static void Main(string[] args)
        {
            List<Jatekos> focistak = new List<Jatekos>()
            {
                new Jatekos("Job John", "kapus", 0),
                new Jatekos("Bright Noa", "vedő", 2),
                new Jatekos("Kai Shiden", "támadó", 3),
                new Jatekos("Amuro Ray", "középpályás", 3),
                new Jatekos("Ryu Hose", "támadó", 7),
                new Jatekos("Hayato Kobayashi", "középpályás", 1)
            };

            focistak[3].Gol += 5;

            focistak.Sort();

            focistak.Remove(focistak[^1]);
            foreach (Jatekos f in focistak)
            {
                Console.WriteLine(f.ToString());
            }
            Console.WriteLine("------------");
            Console.WriteLine(focistak[0]);

            Stack<Jatekos> fociverem = new Stack<Jatekos>();
            fociverem.Push(focistak[0]);
            fociverem.Push(focistak[1]);
            fociverem.Push(focistak[2]);
            int fociIndex = fociverem.Count;
            for (int i = 0; i < fociIndex; i++)
            {
                Console.WriteLine(fociverem);
                fociverem.Pop();
            }

        }
    }
}