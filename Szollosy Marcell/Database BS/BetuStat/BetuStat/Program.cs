class Program
{
    static void Main(string[] args)
    {
        /*
        List<string> orszagok = new List<string>();

        orszagok.Add("Magyarország");
        orszagok.Add("Nemetorszag");
        orszagok.Add("Franciaorszag");

        foreach (var item in orszagok)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("\n-------------------\n A verem elemei");
        Stack<int> myStack = new Stack<int>();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);

        System.Console.WriteLine(string.Join(",", myStack));

        System.Console.WriteLine("A kivett elem: " + myStack.Pop());
        Console.WriteLine(string.Join(",", myStack));

        System.Console.Writeline("------------------\nA sor elemei: ")
        Queue<int> q1 = new Queue<int>();
        q1.Enqueue(1);
        q1.Enqueue(2);
        q1.Enqueue(3);
        q1.Enqueue(4);

        Console.WriteLine(string.Join(", ", q1));

        System.Console.WriteLine(q1.Count);

        System.Console.WriteLine("A kivetett elem: " + q1.Dequeue);
        Console.WriteLine(string.Join(", ", q1));

        System.Console.Writeline("A legelső elem: " + q1.Peek());
        Console.WriteLine(string.Join(", ", q1));

        System.Console.WriteLine("Tartalmazza az 1-et a sor?" + q1.Contains(1))

        System.Console.WriteLine("Tartalmazza a 4-et a sor?" + q1.Contains(4));
        
        HashSet<int> ParosSzamok = [2, 4, 6, 8, 10];

        HashSet<string> hSetCountries = new HashSet<string> { "India", "USA", "UK" };

        //Console.WriteLine(string.Join(",", parosSzamok));

        foreach (var item in hSetCountries)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("A halmaz elemeinek a száma: " + hSetCountries.Count);

        hSetCountries.remove("India");
        Console.Writeline(string.Join(", ", hSetCountries));

        hSetCountries.clear();
        system.console.WriteLine("A halmaz elemeinek a száma: " + hSetCountries.Count);

        System.Console.Writeline("Benne van-e a halmazban a 2?" + ParosSzamok.Conatins(2));
        System.Console.Writeline("Benne van-e a halmazban a 3?" + ParosSzamok.Conatins(3));

        HashSet<int> oszthato4Halmaz = new HashSet<int> { 4, 8, 12, 16, 20 };
        Console.Writeline(string.Join(", ", ParosSzamok));
        Console.Writeline(string.Join(", ", oszthato4Halmaz));
        ParosSzamok.UionWith(oszthato4Halmaz);
        Console.WriteLine("A 2 halmaz úniója: " + string.Join(", ", ParosSzamok));

        ParosSzamok.IntersectWith(oszthato4Halmaz);
        Console.WriteLine("A 2 halzmaz metszete: " + string.Join(",", ParosSzamok));
        */

        Dictionary<int, string> sub = new Dictionary<int, string>();
        sub.Add(1, "C#");
        sub.Add(2, "Java");
        sub.Add(3, "Python");

        foreach (var item in sub)
        {
            System.Console.WriteLine($"Key: {item.Key}, value:{item.Value}");
        }

        System.Console.WriteLine($"Sub dict első eleme: {sub[1]}");

        for (int i = 0; i < sub.Count; i++)
        {
            Console.WriteLine(
                "Key: {0}, Value: {1}",
                sub.Keys.ElementAt(i),
                sub[sub.Keys.ElementAt(i)]
            );
        }


        sub.Remove(1);
        System.Console.WriteLine(string.Join('\n', sub));

        var cities = new Dictionary<string, string>()
        {
            { "UK", "London, Manchester, Birmingham" },
            { "USA", "Chichago, New York, Washington" },
            { "India", "Mumbai, New Delhi, Pune"},
        };

        Console.WriteLine(string.Join("\n", cities));

        if (cities.ContainsKey("USA"))
        {
            System.Console.WriteLine("Amerikai városok: " + cities["USA"]);
        }
        if (!cities.ContainsKey("USA"))
        {
            System.Console.WriteLine("Francia városok: " + cities["France"]);
        }
        else
        {
            System.Console.WriteLine("Ez a kulcs nincs benne a szótárban.");
        }

        System.Console.WriteLine("Kérem adjon egy szót: ");
        string szo = Console.ReadLine().ToLower();

        Dictionary<char, int> stat = new Dictionary<char, int>();

        foreach (char c in szo)
        {
            if (char.IsLetter(c))
            {
                if (!stat.ContainsKey(c))
                {
                    stat[c] = 1;
                }
                else
                {
                    stat[c]++;
                }
            }
        }
        System.Console.WriteLine(string.Join ("\n", stat));
    }
}
