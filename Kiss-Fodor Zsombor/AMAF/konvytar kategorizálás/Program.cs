namespace konvytar_kategorizálás
{
    internal class Program
    {
        class Konyv : IComparable<Konyv>
        {
            public string Cim { get; set; }
            public int Oldalszam { get; set; }
            public int KiadasiEv { get; set; }
            public string Reszleg { get; set; }

            public Konyv(string cim, int oldalszam, int kiadasiEv, string reszleg)
            {
                Cim = cim;
                Oldalszam = oldalszam;
                KiadasiEv = kiadasiEv;
                Reszleg = reszleg;
            }

            public override string ToString()
            {
                return Cim;
            }

            public int CompareTo(Konyv? other) 
            {
                if (other.Reszleg.CompareTo(this.Reszleg) == 0) 
                {
                    return (other.Cim.CompareTo(this.Cim));
                }
                else
                {
                    return (other.Reszleg.CompareTo(this.Reszleg));
                }
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
}