using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, int year, double price)
    {
        Title = title;
        Author = author;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"Cím: {Title}, Szerző: {Author}, Év: {Year}, Ár: {Price} Ft";
    }

    public int CompareTo(Book other)
    {
        if (other == null) return 1;

        int priceComparison = Price.CompareTo(other.Price);
        if (priceComparison != 0)
            return priceComparison;

        return string.Compare(Title, other.Title, StringComparison.Ordinal);
    }
}

public class BookYearComparer : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        if (y == null) return 1;
        if (x == null) return -1;

        int yearComparison = x.Year.CompareTo(y.Year);
        if (yearComparison != 0)
            return yearComparison;

        
        return y.Price.CompareTo(x.Price);
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        List<Book> Book = new List<Book>();
        {
            Book.Add(new Book("Lord of the Rings", "J.R.R. Tolkien.", 1954, 15000));
            Book.Add(new Book("Harry Potter", "J. K. Rowling", 1997, 13500));
            Book.Add(new Book("Moby Dick", "Herman Melville", 1990, 296));
            Book.Add(new Book("The Hunt for the Red October", " Tom Clancy", 1990, 33647));
            Book.Add(new Book("War Games", " Lawrence Lasker", 1983, 4037));
        };

        
        Console.WriteLine("Eredeti lista:");
        foreach (var book in Book)
        {
            Console.WriteLine(book);
        }


        Book.Sort();
        Console.WriteLine("\nRendezett lista (ár szerint növekvő, majd cím szerint):");
        foreach (var book in Book)
        {
            Console.WriteLine(book);
        }

        
        Console.WriteLine("\n--- Dictionary keresés ---");
        Dictionary<string, Book> bookDict = new Dictionary<string, Book>();
        foreach (var book in Book)
        {
            bookDict[book.Title] = book;
        }

        Console.Write("Kérem a keresett könyv címét: ");
        string input = Console.ReadLine();

        if (bookDict.TryGetValue(input, out Book foundBook))
        {
            Console.WriteLine(foundBook);
        }
        else
        {
            Console.WriteLine("Nincs ilyen könyv a rendszerben.");
        }

        Console.WriteLine("\n--- Év szerint rendezve (csökkenő ár azonos év esetén) ---");
        Book.Sort(new BookYearComparer());
        foreach (var book in Book)
        {
            Console.WriteLine(book);
        }
    }
}