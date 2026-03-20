using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

class Sportolo
{
    public int Helyezes { get; set; }
    public double Eredmeny { get; set; }
    public string Nev { get; set; }
    public string Orszag { get; set; }
    public string Helyszin { get; set; }
    public DateTime Datum { get; set; }

    public Sportolo(string sor)
    {
        var adatok = sor.Split(';');

        Helyezes = int.Parse(adatok[0]);
        Eredmeny = double.Parse(adatok[1], CultureInfo.InvariantCulture);
        Nev = adatok[2];
        Orszag = adatok[3];
        Helyszin = adatok[4];
        Datum = DateTime.Parse(adatok[5]);
    }
}

class Program
{
    static void Main()
    {
        // 3. feladat
        List<Sportolo> lista = new List<Sportolo>();

        var sorok = File.ReadAllLines("kalapacsvetes.txt").Skip(1);

        foreach (var sor in sorok)
        {
            lista.Add(new Sportolo(sor));
        }

        // 4. feladat
        Console.WriteLine($"4. feladat: Dobások száma: {lista.Count}");

        // 5. feladat
        var magyarok = lista.Where(x => x.Orszag == "HUN");

        double atlag = magyarok.Average(x => x.Eredmeny);

        Console.WriteLine($"5. feladat: Magyar sportolók átlaga: {atlag:F2} m");

        // 6. feladat
        Console.Write("6. feladat: Adj meg egy évet: ");
        int ev = int.Parse(Console.ReadLine());

        var talalatok = lista.Where(x => x.Datum.Year == ev);

        if (talalatok.Any())
        {
            Console.WriteLine($"Dobások száma: {talalatok.Count()}");

            foreach (var t in talalatok)
            {
                Console.WriteLine($"- {t.Nev}");
            }
        }
        else
        {
            Console.WriteLine("Ebben az évben nem került be dobás.");
        }

        // 7. feladat
        Console.WriteLine("7. feladat: Statisztika");

        var stat = lista.GroupBy(x => x.Orszag)
                        .OrderBy(x => x.Key);

        foreach (var csoport in stat)
        {
            Console.WriteLine($"{csoport.Key}: {csoport.Count()} db");
        }

        // 8. feladat
        var hun = lista.Where(x => x.Orszag == "HUN");

        File.WriteAllLines("magyarok.txt",
            hun.Select(x => $"{x.Helyezes};{x.Eredmeny:F2};{x.Nev};{x.Orszag};{x.Helyszin};{x.Datum:yyyy.MM.dd}"));

        Console.WriteLine("8. feladat: magyarok.txt létrehozva.");
    }
}