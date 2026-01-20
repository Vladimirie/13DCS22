namespace _202051216
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Kérlek adjon meg egy számot: ");
                string be = null;
                be = Console.ReadLine();
                var num = int.Parse(be);
                Console.WriteLine(num * num);
            }
            catch (IOException) 
            {
                
            } 

        }
    }
}
