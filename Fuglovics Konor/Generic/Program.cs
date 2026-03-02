namespace Generic
{
	internal class DataStore<T>
	{
		public T Data { get; set; }
		private readonly T[] _Datas = new T[10];
		public void Add(int index, T item)
		{
			if(index >= 0 && index < 10)
			{
				_Datas[index] = item;
			}
		}
		public T? GetData(int index)
		{
			if (index >= 0 && index < 10)
			{
				return _Datas[index];
			}
			else
			{
				return default;
			}
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
			DataStore<string> store = new();
			store.Data = "Hello World.";
			DataStore<int> storeint = new();
			storeint.Data = 123;
			DataStore<string> cities = new();
			cities.Add(0, "Budapest");
			cities.Add(1, "Bukarest");
			cities.Add(2, "Bécs");
			for(int i = 0; i < 3; i++)
			{
				Console.WriteLine(cities.GetData(i));
			}
			Console.ReadKey();
        }
    }
}
