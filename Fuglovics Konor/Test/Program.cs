namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Input:
				string a = Console.ReadLine();
				string b = int.Parse(a)>100?"Nagyobb":((int.Parse(a)<100)?"Kisebb":"Egyenlő");
				Console.WriteLine(b);
			while(a.ToString() != "exit")
			{
				goto Input;
			}
			Console.ReadKey();
        }
    }
}
