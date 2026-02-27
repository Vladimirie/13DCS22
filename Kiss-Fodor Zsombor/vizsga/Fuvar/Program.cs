namespace Fuvar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string file = "fuvar.csv";
            List<fuvar> list = ReadFile(file);

            Console.WriteLine($"3. feladat: {list.Count} fuvar");
            Console.WriteLine(DriverInfo(6185, list));

            Console.WriteLine("5. feladat:");
            Dictionary<string, int> paymentList = PaymentMethods(list);
            foreach (var payment in paymentList) 
            {
                Console.WriteLine($"\t {payment.Key}: {payment.Value} fuvar");
            }

            Console.WriteLine($"6. feladat: {TotalDistance(list)}km");

            Console.WriteLine("7. feladat: Leghoszabb fuvar: ");
            LongestTravel(list);

            Console.ForegroundColor = ConsoleColor.White;
        }

        static List<fuvar> ReadFile(string file)
        {
            string[] taxiArray = File.ReadAllLines(file);
            List<fuvar> taxiList = new List<fuvar>();

            for (int i = 1; i < taxiArray.Length; i++)
            {
                string[] taxiString = taxiArray[i].Split(';');
                taxiList.Add(
                    new fuvar(
                        int.Parse(taxiString[0]),
                        Convert.ToDateTime(taxiString[1]),
                        int.Parse(taxiString[2]),
                        float.Parse(taxiString[3]),
                        float.Parse(taxiString[4]),
                        float.Parse(taxiString[5]),
                        taxiString[6]
                        )
                    );
            }

            return taxiList;
        }

        static string DriverInfo(int TaxiID, List<fuvar> fuvarosok)
        {
            float income = 0;
            int drives = 0;
            foreach (var fuvaros in fuvarosok)
            {
                if (fuvaros.TaxiId == TaxiID)
                {
                    drives++;
                    income += fuvaros.Cost;
                }
            }
            return $"4. feladat: {drives} fuvar alatt: ${income}";
        }

        static Dictionary<string, int> PaymentMethods(List<fuvar> fuvarosok)
        {
            Dictionary<string, int> payments = new Dictionary<string, int>();

            foreach (var fuvar in fuvarosok)
            {
                if (payments.ContainsKey(fuvar.PaymentMethod))
                {
                    payments[fuvar.PaymentMethod]++;
                }
                else
                {
                    payments.Add(fuvar.PaymentMethod, 1);
                }               
            }

            return payments;
        }

        static double TotalDistance(List<fuvar> fuvarosok)
        {
            float totalDist = 0;

            foreach (var fuvar in fuvarosok)
            {
                totalDist += fuvar.TravelledDistance;
            }

            double doubleDist = totalDist * 1.6f;

            return Math.Round(doubleDist, 2);
        }

        static void LongestTravel(List<fuvar> fuvarosok)
        {
            //float longestDist = fuvarosok[0].TravelledDistance;

            var longestAhhTravel = fuvarosok.OrderBy(f => f.TravelTime).Reverse().First();

            Console.WriteLine($"\tFuvar hossza: {longestAhhTravel.TravelTime} másodperc");
            Console.WriteLine($"\tTaxi azonosító: {longestAhhTravel.TaxiId}");
            Console.WriteLine($"\tMegtett távolság hossza: {longestAhhTravel.TravelledDistance} km");
            Console.WriteLine($"\tViteldíj: ${longestAhhTravel.Cost}");
        }


        //uccsó feladat
    }
}
