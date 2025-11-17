class Program
{
    static void Main(string[] args)
    {
        string fajlNév = "konyvek.txt";
        string[] sorok = File.ReadAllLines(fajlNév);
        List<Konyvtar> konyvek = new List<Konyvtar>();
        int db = int.Parse(sorok[0]);
        for (int i = 1; i < db + 1; i++)
        {
            string[] adatok = sorok[i].Split(';');
        }
    }
}