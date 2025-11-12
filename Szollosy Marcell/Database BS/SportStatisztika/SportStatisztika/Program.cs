using System.ComponentModel;

class Jatakos: IComparable<Jatakos>
{
    public Jatakos(string nev, int golok, string poszt)
    {
        Nev = nev;
        Golok = golok;
        Poszt = poszt;
    }

    public string Nev { get; set; }
    public int Golok { get; set; }
    public string Poszt { get; set; }

    public int CompareTo(Jatakos? other)
    {
        //csökkenő sorrend
        if (other.Nev.CompareTo(this.Golok) == 0)
        {
            return this.Nev.CompareTo(other.Nev);
        }
        else
        {
            return other.Golok.CompareTo(this.Golok);
        }



        //novekvő sorrend
        //return this.Golok.CompareTo(other.Golok);
    }

    public override string Tostring()
    {
        return $"Játékos neve: {Nev}, posztja: {Poszt}, gólszáma: {Golok}";
    }
}

class Program
{ 

    static void Main(string[] args)
    {
    List<Jatakos> jatekosok = new List<Jatakos>();
        jatekosok.Add(new Jatakos("Laci", 3,  "Csatár"));
        jatekosok.Add(new Jatakos("István", 2, "Kapus"));
        jatekosok.Add(new Jatakos("Jankó", 0, "Csatár"));
        jatekosok.Add(new Jatakos("Dávid", 4, "Védő"));
        jatekosok.Add(new Jatakos("Tibor", 5, "Csatár"));
        jatekosok.Add(new Jatakos("Jankó", 3, "Védő"));

        jatekosok[3].Golok += 5;
    }
}