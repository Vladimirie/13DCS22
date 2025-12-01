namespace generikusok
{
    internal class Program
    {
        class Generikum<T>
        {
            public T Data { get; set; }
        }

        static void Main(string[] args)
        {
            Generikum<string> strKum = new Generikum<string>();
            strKum.Data = "Hoi Wurd";
            
            Generikum<int> intKum = new Generikum<int>();
            intKum.Data = 123;
        }
    }
}