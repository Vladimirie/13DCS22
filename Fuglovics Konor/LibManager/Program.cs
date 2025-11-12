<<<<<<< HEAD
﻿using System.Security.Cryptography.X509Certificates;

namespace LibManager
{
	internal class Book : IComparable<Book>
	{
		public string Title
		{
			get;
			set;
		}
		public string Author
		{
			get;
			set;
		}
		public int Year
		{
			get;
			set;
		}
		public double Price
		{
			get;
			set;
		}
		public Book(string title, string author, int year, double price)
		{
			Title = title;
			Author = author;
			Year = year;
			Price = price;
		}
		public int CompareTo(Book? other)
		{
			if(Price.CompareTo(other.Price) == 0)
			{
				return Title.CompareTo(other.Title);
			}
			return Price.CompareTo(other.Price);
		}
		public override string? ToString()
		{
			return $"Title: {Title}, Author: {Author}, Year published: {Year}, Price: {Price} Ft";
		}
	}
	internal class BookYearComparer : IComparer<Book>
	{
		public int Compare(Book? x, Book? y)
		{
			if(x == null || y == null)
			{
				throw new ArgumentException("Nem lehet üres!");
			}
			if(x.Year.CompareTo(y.Year)!=0)
			{
				return x.Year.CompareTo(y.Year);
			}
			return y.Price.CompareTo(x.Price);
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Book> books =
			[
				new Book("Egri Csillagok", "Gárdonyi Géza", 1899, 3990),
				new Book("1984", "George Orwell", 1949, 5628.60),
				new Book("Chocolate Cake", "Michael Rosen", 2017, 3742.29),
				new Book("Az Arany Ember", "Jókai Mór", 1872, 3790),
				new Book("Légy jó mindhalálig", "Móricz Zsigmond", 1920, 3290),
			];
			books.Sort();
			foreach(var book in books)
			{
				Console.WriteLine(book);
			}
			books.Sort(new BookYearComparer());
			Console.WriteLine("");
			foreach (var book in books)
			{
				Console.WriteLine(book);
			}
			Dictionary<string, Book> catalog = [];
			foreach(var b in books)
			{
				catalog[b.Title] = b;
			}
			//Console.WriteLine($"{string.Join("\n",catalog)}\n");
			Console.Write("\nKeresés: ");
			string userbook = Console.ReadLine();
			if(catalog.ContainsKey(userbook))
			{
				Console.WriteLine(catalog[userbook]);
			}
			else
			{
				Console.WriteLine($"Nincsen {userbook} nevű könyv");
			}
			Console.ReadKey();
		}
	}
}
=======
﻿using System.Security.Cryptography.X509Certificates;

namespace LibManager
{
	internal class Book : IComparable<Book>
	{
		public string Title
		{
			get;
			set;
		}
		public string Author
		{
			get;
			set;
		}
		public int Year
		{
			get;
			set;
		}
		public double Price
		{
			get;
			set;
		}
		public Book(string title, string author, int year, double price)
		{
			Title = title;
			Author = author;
			Year = year;
			Price = price;
		}
		public int CompareTo(Book? other)
		{
			if(Price.CompareTo(other.Price) == 0)
			{
				return Title.CompareTo(other.Title);
			}
			return Price.CompareTo(other.Price);
		}
		public override string? ToString()
		{
			return $"Title: {Title}, Author: {Author}, Year published: {Year}, Price: {Price} Ft";
		}
	}
	internal class BookYearComparer : IComparer<Book>
	{
		public int Compare(Book? x, Book? y)
		{
			if(x == null || y == null)
			{
				throw new ArgumentException("Nem lehet üres!");
			}
			if(x.Year.CompareTo(y.Year)!=0)
			{
				return x.Year.CompareTo(y.Year);
			}
			return y.Price.CompareTo(x.Price);
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Book> books =
			[
				new Book("Egri Csillagok", "Gárdonyi Géza", 1899, 3990),
				new Book("1984", "George Orwell", 1949, 5628.60),
				new Book("Chocolate Cake", "Michael Rosen", 2017, 3742.29),
				new Book("Az Arany Ember", "Jókai Mór", 1872, 3790),
				new Book("Légy jó mindhalálig", "Móricz Zsigmond", 1920, 3290),
			];
			books.Sort();
			foreach(var book in books)
			{
				Console.WriteLine(book);
			}
			books.Sort(new BookYearComparer());
			Console.WriteLine("");
			foreach (var book in books)
			{
				Console.WriteLine(book);
			}
			Dictionary<string, Book> catalog = [];
			foreach(var b in books)
			{
				catalog[b.Title] = b;
			}
			//Console.WriteLine($"{string.Join("\n",catalog)}\n");
			Console.Write("\nKeresés: ");
			string userbook = Console.ReadLine();
			if(catalog.ContainsKey(userbook))
			{
				Console.WriteLine(catalog[userbook]);
			}
			else
			{
				Console.WriteLine($"Nincsen {userbook} nevű könyv");
			}
			Console.ReadKey();
		}
	}
}
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
