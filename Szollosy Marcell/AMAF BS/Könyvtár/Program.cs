class Program
{
    static void Main(string[] args)
    {
        string fajlNév = "konyvek.txt";
        StreamReader Be = new StreamReader(fajlNév);
        SortedDictionary<string, List<Konyvtár>> Konyvtár =
            new SortedDictionary<string, List<Konyvtár>>();
        while (!Be.EndOfStream)
        {
            string sor = Be.ReadLine();
            string[] adatok = sor.Split(';');
            Konyvtár k = new Konyvtár(
                adatok[0],
                int.Parse(adatok[1]),
                int.Parse(adatok[2]),
                adatok[3]
            );
            if (!eredmenyKonyvtár.ContainsKey(k.Részleg))
            {
                eredmenyKonyvtár.Add(k.Részleg, new List<Konyvtár>());
            }
            eredmenyKonyvtár[k.Részleg].Add(k);
        }
        Be.Close();

        var rendezett = Konyvtár
            .GroupBy(k => k.Részleg);
            .OrderBy(r => r.Részleg);
            .ToList();

            foreach (var részleg in részlegek)
            {
                Console.WriteLine(részleg.Key + ":");
                var rendezett = részleg
                    .OrderByDescending(k => k.KiadasiEv)
                    .ThenBy(k => k.Oldal)
                    .ThenBy(k => k.Cim);
                Console.WriteLine(string.Join("\n", rendezett));
            }
        /*foreach (var részleg in eredmenyKonyvtár.Keys)
        {
            Console.WriteLine(részleg + ":");
            //Console.WriteLine(string.Join("\n", eredmenyKonyvtár[részleg]));
            var rendezett = eredmenyKonyvtár[részleg]
                .OrderByDescending(k => k.KiadasiEv)
                .ThenBy(k => k.Oldal)
                .Thenby(k => k.Cim)
                .ToList();

            Console.WriteLine(string.Join("\n", rendezett));
        }*/
    }   
}
