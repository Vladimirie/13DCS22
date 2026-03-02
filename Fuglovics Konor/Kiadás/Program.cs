namespace Kiadás
{
	internal class Book
	{
		public int RelYear
		{
			get;
			set;
		}
		public string Origin
		{
			get;
			set;
		}
		public string Author
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public int Copies
		{
			get;
			set;
		}
		public Book(int relyear, string origin, string author, string title, int copies)
		{
			RelYear = relyear;
			Origin = origin;
			Author = author;
			Title = title;
			Copies = copies;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> data = [];
			foreach(var line in File.ReadAllLines("kiadas.txt"))
			{
				string[] scan = line.Split(";");
				string auth;
				string ttl;
				if(scan[3].Contains(": "))
				{
					string[] scan2 = scan[3].Split(": ");
					auth = scan2[0];
					ttl = scan2[1];
				}
				else
				{
					int i = scan[3].IndexOf("(");
					int i2 = scan[3].IndexOf(")");
					auth = scan[3].Substring(i, i2);
					ttl = scan[3].Substring(0, i);

				}
				Book db = new Book(int.Parse(scan[0]), scan[1], scan[2], scan[3], int.Parse(scan[4]));
			}
        }
    }
}