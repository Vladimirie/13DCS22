class Program
{
    static void Main(string[] args)
    {
        string fajlNév = "karakterek.txt";
        StreamReader be = new StreamReader(fajlNév);
        SortedDictionary<string, List<karakterek>> karakterek =
            new SortedDictionary<string, List<karakterek>>();
        while (!be.EndOfStream)
        {
            string sor = be.ReadLine();
            string[] adatok = sor.Split(';');
            karakterek k = new karakterek(
                adatok[0],
                int.Parse(adatok[1]),
                int.Parse(adatok[2]),
                adatok[3]
            );
            if (!eredmenykarakterek.ContainsKey(k.karakter))
            {
                eredmenykarakterek.Add(k.karakter, new List<karakterek>());
            }
            eredmenykarakterek[k.karakter].Add(k);
        }
        be.Close();

        var rendezett = karakterek.GroupBy(k => k.karakter).OrderBy(k => k.karakter).ToList();
    }
}
