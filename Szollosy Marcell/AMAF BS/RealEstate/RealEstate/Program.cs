using RealEstate;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. feladat:");
        var ads = Ad.LoadFromCsv("realestates.csv");
        Console.WriteLine($"Beolvasott hirdetések száma: {ads.Count}");

        Console.WriteLine("\n6. feladat:");
        var groundFloor = ads.Where(a => a.Floors == 0);
        double averageArea = groundFloor.Average(a => a.Area);
        Console.WriteLine($"A földszinti ingatlanok átlagos alapterülete: {averageArea:F2} m2");

        Console.WriteLine("\n8. feladat:");
        double targetLat = 47.4164220114023;
        double targetLon = 19.066342425796986;

        var closest = ads
            .Where(a => a.FreeOfCharge)
            .OrderBy(a => a.DistanceTo(targetLat, targetLon))
            .First();

        Console.WriteLine("A legközelebbi tehermentes ingatlan:");
        Console.WriteLine($"Azonosító: {closest.Id}");
        Console.WriteLine($"Alapterület: {closest.Area}");
        Console.WriteLine($"Szobák száma: {closest.Rooms}");
        Console.WriteLine($"Távolság: {closest.DistanceTo(targetLat, targetLon):F6}");
    }
}