using System.Linq;

namespace _2025._10._02
{
    class program
    {
        static void Main(string[] args)
        {
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

            Console.Writeline("------------------\nA sor elemei: ")
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



        }
    }
}
