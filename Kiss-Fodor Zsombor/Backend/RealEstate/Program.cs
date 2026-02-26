using System.Linq;

namespace RealEstate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileToRead = "realestates.csv";
            var hazak = Ad.LoadFromCSV(fileToRead);

            foreach (var item in hazak)
            {
                Console.WriteLine(item);
            }

            //6. feladat
            var atlagAdat = hazak.Where(a => a.Floors == 0).Average(a => a.Area);
            Console.WriteLine(atlagAdat.ToString());
        }
    }
}
