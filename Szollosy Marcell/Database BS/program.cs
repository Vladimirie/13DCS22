class Person
{
    public string Name;

    public static int Count = 0;

    public Person(string name)
    {
        Name = name;
        Count++;
    }
}

class UnitConverter
{
    public static double KgToLbs(double weight) => weight * 2.20462262185;
    public static double LbsToKg(double weight) => weight * 0.45359237;
}

class RandomNumber
{
    private static Random random;

    static RandomNumber()
    {
        random = new Random();
    }

    public int Get() => random.Next();
}

class Program
{
    static void Main(string[]args)
    {
        var p1 = new Person("Marcell");
        var p2 = new Person("Zsombor");

        System.Console.WriteLine($"p1 Name: {p1.Name}");
        System.Console.WriteLine($"p2 Name: {p2.Name}");

        double weight = UnitConverter.KgToLbs(100);
        System.Console.WriteLine($"100kg= {weight:#.00} lbs");
        double weight = UnitConverter.LbsToKg(100);
        System.Console.WriteLine($"100lbs= {weight:#.00} kg");

        System.Console.WriteLine("-----------------");

        Random random = new();
    }


}

