namespace BookData
{
	internal class Book
	{
		public int Year
		{
			get;
			set;
		}
		public int QYear
		{
			get;
			set;
		}
		public string Region
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
		public int Amount
		{
			get;
			set;
		}
		public Book(int year, int qyear, string region, string author, string title, int amount)
		{
			Year = year;
			QYear = qyear;
			Region = region;
			Author = author;
			Title = title;
			Amount = amount;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> mem = [];
        }
    }
}
