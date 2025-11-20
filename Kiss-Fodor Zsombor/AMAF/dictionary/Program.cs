namespace dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> sub = new Dictionary<int,string>();

            sub.Add(1, "C#");
            sub.Add(2, "Java");
            sub.Add(3, "Python");

            SubWrite(sub);

            sub.Remove(2);

            SubWrite(sub);

            var cities = new Dictionary<string,string>()
            {
                {"UK", "BIRMINGHAM" },
                {"US", "New York" }
            };

            if (cities.ContainsKey("US"))
            {
                Console.WriteLine(cities["US"]);
            }

            Console.WriteLine("______________________________");

            Console.Write("Adjon meg egy szót vagy mondatot:");
            string bemenet = Console.ReadLine();
            var betuDictionary = new Dictionary<char, int>();
            
            foreach (char betu in bemenet.ToLower()) 
            {
                if (betu != ' ' && char.IsLetter(betu))
                {
                    if (betuDictionary.ContainsKey(betu))
                    {
                        betuDictionary[betu]++;
                    }
                    else
                    {
                        betuDictionary.Add(betu, 1);
                    }         
                }
            }

            if (betuDictionary.Count != 0)
            {
                Console.WriteLine($"Ezek a betű vannak a(z) '{bemenet}' szóban/szövegben");
                foreach (var betuk in betuDictionary)
                {
                    Console.WriteLine($"A(z) {betuk.Key} betű benne van {betuk.Value} alkalommal");
                }
            }
            else
            {
                Console.WriteLine("Ebben a szóban/mondatban nincs betű");
            }
            
            
        }



        static void SubWrite(Dictionary<int, string> dikk)
        {
            foreach (var item in dikk)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
    }
}
