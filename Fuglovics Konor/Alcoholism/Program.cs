namespace Alcoholism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alkohol> adat = [];
			foreach(var fájl in File.ReadAllLines("drinks_hu.csv").Skip(1))
			{
				string[] sor = fájl.Split(",");
				adat.Add(new Alkohol(sor[0], int.Parse(sor[1]), int.Parse(sor[2]), int.Parse(sor[3]), double.Parse(sor[4])));
			}
			Console.WriteLine($"{adat.Count} ország adatai szerepelnek.\n");
			var tsztalkhl = adat.Where(a => a.Tiszta_alkohol_Liter >= 10).Count();
			Console.WriteLine($"{tsztalkhl} ország van, ami meghaladja a 10 Litert\n");
			var legrészegebb = adat.Select(b => b.Söradagok).Max();
			var legrészegebb_ország = adat.Where(c => c.Söradagok == legrészegebb).First();
			Console.WriteLine($"A legtöbb sört fogyasztó ország: {legrészegebb_ország.Ország}\n\tSöradagok száma: {legrészegebb_ország.Söradagok}\n\tTiszta alkohol mennyiség: {legrészegebb_ország.Tiszta_alkohol_Liter}l\n");
			bool talált = false;
			while (!talált)
			{
				Console.Write("? ");
				string tab = "";
				string keresés = Console.ReadLine();
				foreach(var k in adat)
				{
					if(keresés == k.Ország)
					{
						 for(int i = 0; i < (k.Ország.Length); i++)
						{
							if(i%8 == 0)
							{
								tab += "\t";
							}
						}
						Console.WriteLine($"A keresés eredménye:\n\nOrszág{tab}Söradag\tBoradag\tSzesz menny,\n{k.Ország}\t{k.Söradagok}\t{k.Boradagok}\t{k.Égetett_szesz}\n");
						talált = true;
					}
				}
			}
			var nincsbor = adat.Where(d => d.Boradagok == 0).Count();
			Console.WriteLine($"{nincsbor} ország van, ahol nincsen borfogyasztás");
			Console.ReadKey();
        }
    }
}
