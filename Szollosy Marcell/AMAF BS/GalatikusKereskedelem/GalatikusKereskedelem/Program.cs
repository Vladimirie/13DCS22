using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// 1. feladat – Osztályok létrehozása
public class Kolonia : IComparable<Kolonia>
{
    public string Azonosito { get; set; }
    public string Nev { get; set; }
    public string Szektor { get; set; }
    private int osszesTon = 0;

    public Kolonia(string azonosito, string nev, string szektor)
    {
        Azonosito = azonosito;
        Nev = nev;
        Szektor = szektor;
    }

    public void SetOsszesTon(int ton)
    {
        osszesTon = ton;
    }

    public int CompareTo(Kolonia other)
    {
        int cmp = other.osszesTon.CompareTo(this.osszesTon); // csökkenő
        if (cmp == 0) cmp = this.Nev.CompareTo(other.Nev); // név szerint növekvő
        return cmp;
    }

    public override string ToString()
    {
        return $"{Azonosito} - {Nev} ({Szektor}), Összesen: {osszesTon} tonna";
    }
}

public class Szallitas
{
    public Kolonia Forras { get; set; }
    public Kolonia Cel { get; set; }
    public int Mennyiseg { get; set; }

    public Szallitas(Kolonia forras, Kolonia cel, int mennyiseg)
    {
        Forras = forras;
        Cel = cel;
        Mennyiseg = mennyiseg;
    }

    public override string ToString()
    {
        return $"{Forras.Azonosito} -> {Cel.Azonosito}, {Mennyiseg} tonna";
    }
}

class Program
{
    static void Main()
    {
        // 2. feladat – Adatbeolvasás
        Dictionary<string, Kolonia> koloniak = new Dictionary<string, Kolonia>();
        foreach (string line in File.ReadAllLines("kolonia.csv"))
        {
            var parts = line.Split(';');
            string azonosito = parts[0];
            string nev = parts[1];
            string szektor = parts[2];
            koloniak[azonosito] = new Kolonia(azonosito, nev, szektor);
        }

        List<Szallitas> szallitasok = new List<Szallitas>();
        foreach (string line in File.ReadAllLines("szallitasok.csv"))
        {
            var parts = line.Split(';');
            string forrasAzon = parts[0];
            var celAzon = parts[1];
            var mennyiseg = int.Parse(parts[2]);

            Kolonia forras = koloniak[forrasAzon];
            Kolonia cel = koloniak[celAzon];

            szallitasok.Add(new Szallitas(forras, cel, mennyiseg));
        }

        // 3. feladat – Kimutatások
        Console.WriteLine("=== Kimutatások ===");
        Kimutatasok(koloniak, szallitasok);

        // 4. feladat – Rendezés
        Console.WriteLine("\n=== Rendezett kolóniák ===");
        Rendezes(koloniak, szallitasok);
    }

    static void Kimutatasok(Dictionary<string, Kolonia> koloniak, List<Szallitas> szallitasok)
    {
        // 1. Minden kolónia szállításainak száma
        Console.WriteLine("1. Kolóniák szállításainak száma:");
        foreach (var kol in koloniak.Values)
        {
            var db = szallitasok.Count(s => s.Forras.Azonosito == kol.Azonosito || s.Cel.Azonosito == kol.Azonosito);
            Console.WriteLine($"{kol}: {db} szállításban vett részt");
        }

        // 2. Legforgalmasabb kolónia (összesen szállított tonna)
        Console.WriteLine("\n2. Legforgalmasabb kolónia:");
        var forgalom = new Dictionary<string, int>();
        foreach (var sz in szallitasok)
        {
            if (!forgalom.ContainsKey(sz.Forras.Azonosito)) forgalom[sz.Forras.Azonosito] = 0;
            if (!forgalom.ContainsKey(sz.Cel.Azonosito)) forgalom[sz.Cel.Azonosito] = 0;

            forgalom[sz.Forras.Azonosito] += sz.Mennyiseg;
            forgalom[sz.Cel.Azonosito] += sz.Mennyiseg;
        }
        var legforgalmasabb = forgalom.OrderByDescending(x => x.Value).First();
        Console.WriteLine($"{koloniak[legforgalmasabb.Key]} - {legforgalmasabb.Value} tonna");

        // 3. Szektoronkénti statisztika
        Console.WriteLine("\n3. Szektoronkénti statisztika:");
        var szektorStatisztika = szallitasok
            .GroupBy(s => s.Forras.Szektor)
            .ToDictionary(g => g.Key, g => new { Darab = g.Count(), OsszTon = g.Sum(s => s.Mennyiseg) });

        foreach (var kvp in szektorStatisztika)
        {
            Console.WriteLine($"Szektor: {kvp.Key}, Szállítások: {kvp.Value.Darab}, Összesen: {kvp.Value.OsszTon} tonna");
        }
    }

    static void Rendezes(Dictionary<string, Kolonia> koloniak, List<Szallitas> szallitasok)
    {
        var osszesTon = new Dictionary<string, int>();
        foreach (var sz in szallitasok)
        {
            if (!osszesTon.ContainsKey(sz.Forras.Azonosito)) osszesTon[sz.Forras.Azonosito] = 0;
            if (!osszesTon.ContainsKey(sz.Cel.Azonosito)) osszesTon[sz.Cel.Azonosito] = 0;

            osszesTon[sz.Forras.Azonosito] += sz.Mennyiseg;
            osszesTon[sz.Cel.Azonosito] += sz.Mennyiseg;
        }

        foreach (var kol in koloniak.Values)
        {
            kol.SetOsszesTon(osszesTon.ContainsKey(kol.Azonosito) ? osszesTon[kol.Azonosito] : 0);
        }

        var rendezett = koloniak.Values.ToList();
        rendezett.Sort();

        foreach (var k in rendezett)
        {
            Console.WriteLine(k);
        }
    }
}