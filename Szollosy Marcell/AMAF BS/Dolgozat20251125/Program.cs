using System.ComponentModel.DataAnnotations;

namespace Dolgozat20251125
{
    internal class Program
    {
        class Battle : IComparable<Battle>
        {
            public string Name { get; set; }
            public string Place { get; set; }
            public int Armies { get; set; }
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
                        return (this.Lenght.CompareTo(other.Lenght));
                    }
                }
                else
                {
                    return (other.Armies.CompareTo(this.Armies));
                }
            }
        }

        class BattleStat: IComparable<BattleStat>
        {
            public string EventName { get; set; }
            public int EventYear { get; set; }
            public string[] People { get; set; }

            public BattleStat(string eventName, int eventYear, string[] people)
            {
                EventName = eventName;
                EventYear = eventYear;
                People = people;
            }

            public int CompareTo(BattleStat? other)
            {
                return (other.EventName.CompareTo(this.EventName));
            }
        }

        static void Main(string[] args)
        {
            //1. feladat
            string[] falj = File.ReadAllLines("feladat1.txt");       

            int n = 4;

            List<Battle> feladat1 = new List<Battle>();
            /*
            foreach (string f in falj)
            {
                string[] s = f.Split(";");
                feladat1.Add(new Battle(s[0], s[1], int.Parse(s[2]), s[3]));
            }*/
            for (int i = 0; i < n; i++)
            {
                string[] s = falj[i].Split(";");
                feladat1.Add(new Battle(s[0], s[1], int.Parse(s[2]), s[3]));
            }

            feladat1.Sort();

            foreach (Battle battle in feladat1)
            {
                Console.WriteLine(battle);
            }

            //2. feladat
            string[] falj2 = File.ReadAllLines("feladat2.txt");
            List<BattleStat> feladat2 = new List<BattleStat>();

            for (int i = 0; i < n; i++)
            {
                string[] s = falj2[i].Split(";");
                string[] c = s[1].Split(":");
                string[] p = c[1].Split(","); 

                feladat2.Add(new BattleStat(s[0], int.Parse(c[0]), p));
            }

            SortedDictionary<string, int> personStat = new SortedDictionary<string, int>();
            foreach (BattleStat battle in feladat2)
            {
                for (int i = 0; i < battle.People.Length; i++) 
                { 
                    if (personStat.ContainsKey(battle.People[i]))
                    {
                        personStat[battle.People[i]]++;
                    }
                    else
                    {
                        personStat.Add(battle.People[i], 1);
                    }
                }
            }

            foreach (var person in personStat)
            {              
                if (person.Value > 1)
                {
                    Console.WriteLine($"{person.Key}: {person.Value}");
                }
             
            }
        }
    }
}