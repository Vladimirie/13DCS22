using System.Security.Cryptography;

internal class Program
{
    static void Main()
    {
        string fajlNev = "bemenet.csv";
        string[] sorok = File.ReadAllLines(fajlNev);
        List<Mozi> filmek = new List<Mozi>();
        int db = int.Parse(sorok[0]);
        for (int i = 1; i < db + 1; i++)
        {
            string[] adatok = sorok[i].Split(';');
            string film_cím = adatok[0];
            string műfaj = adatok[1];
            int korhatar = int.Parse(adatok[2]);
            int kezdési_idő = int.Parse(adatok[3]);
            Mozi m = new Mozi(film_cím, műfaj, korhatar, kezdési_idő);
            filmek.Add(m);
        }

        filmek.Sort();
        Console.WriteLine(string.Join("\n", filmek));
    }
}
