namespace Törti_dolgozat_20251125
{
    internal class Program
    {
        class Battle : Icomparable<Battle>
        {
            public string Name{ get; set; }
            public string Place { get; set; }
            public int Armies{ get; set; }
            public string Lenght { get; set; }

            public Battle(string name, string place, int armies, string lenght)
            {
                Name = name;
                Place = place;
                Armies = armies;
                Lenght = lenght;
            }

            public override string ToString()
            {
                return $"{Name} ({Place}) : {Lenght}";
            }

            public int CompareTo(Battle? other)
            {
                if (other.Armies.CompareTo(this.Armies) == 0)
                {                  
                    if (other.Lenght.CompareTo(this.Lenght) == 0)
                    {
                        return (other.Name.CompareTo(this.Name));
                    }
                    else
                    {
                        return(this.Lenght.CompareTo(other.Lenght));
                    }
                }
                else
                {
                    return (other.Armies.CompareTo(this.Armies));
                }
            }
        }

        static void Main(string[] args)
        {
            string[] falj = File.ReadAllLines("feladat1.txt");
            string[] falj2 = File.ReadAllLines("feladat1.txt");

            int n = 4;

            List<Battle> feladat1 = new List<Battle>();
            foreach (string f in falj)
            {
                string[] s = f.Split(";");
                feladat1.Add(new Battle(s[0], s[1], int.Parse(s[2]), s[3]));
            }


        }
    }
}
