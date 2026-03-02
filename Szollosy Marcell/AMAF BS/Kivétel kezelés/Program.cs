namespace Kivételkezelés
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student s1 = null;
                string name = s1.StudentName;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Nincs ilyen tanulo.");
            }
            finally
            {
                System.Console.WriteLine("Lefutott.");
            }
        }
    }
}
