using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarkezelo
{
    internal class Program
    {
        class Book : IComparable<Book>
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
            public double Price { get; set; }


            public string toString() { return $" Cím: {Title} Szerző: {Author} Kiadás:  {Year} Ár:  {Price}FT "; }

            public int CompareTo(Book other)
            {
             
                
                if (this.Price.CompareTo(other.Price) == 0)
                {
                    return this.Title.CompareTo(other.Title);
                }
                else
                {
                    return this.Price.CompareTo(other.Price);
                }

                

           

            }

            public Book(string title, string author, int year, double price)
            {
                Title = title;
                Author = author;
                Year = year;
                Price = price;
            }
        }

        class BookYearComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                if (x == null || y == null)
                {
                    throw new ArgumentException("Nem lehet a könyv üres");
                }

                if (x.Year.CompareTo(y.Year) == 0)
                {
                    return y.Price.CompareTo(x.Price);
                }
                else
                {
                    return x.Year.CompareTo(y.Year);
                }
            }
        }
        static void Main(string[] args)
        {

            List<Book> Books = new List<Book>();
            Books.Add(new Book("Egri Csilagok", "Gárdonyi géza", 1899, 3990.00));
            Books.Add(new Book("A pál utrcai fiúk", "Molnár Ferenc", 1900, 3290.00));
            Books.Add(new Book("Abigel", "Szabó magdolna", 1872, 4299.99));
            Books.Add(new Book("Az arany ember", "Jókai Mór", 1962, 1899.99));
            Books.Add(new Book("Légy jó mindhalálig", "Móricz Zsigmond", 1920, 5321.99));




            Books.Sort();


            Dictionary<string, Book> katalogus = new Dictionary<string, Book>();
            foreach (Book book in Books)
            {

                katalogus.Add(book.Title, book);

            }

            Console.WriteLine("Kereset könyv?");
            string bekertcim = Console.ReadLine().Trim();
            if (katalogus.ContainsKey(bekertcim))
            {
                Console.WriteLine(katalogus[bekertcim].toString());

            }
            else {
                Console.WriteLine("Nincs ilyen könyv a rendszerben.");
            }


            Books.Sort(new BookYearComparer());

            foreach (Book book in Books) { 
                Console.WriteLine(book.toString());
            }

            Console.ReadLine();
        }
    }
}
