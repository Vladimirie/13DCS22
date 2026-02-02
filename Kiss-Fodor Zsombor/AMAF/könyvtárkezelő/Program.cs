namespace könyvtárkezelő
{

    class BookYearCompaprer : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            if (x.Year.CompareTo(y.Year) != 0)
            {
                return x.Year.CompareTo(y.Year);
            }
            else
            {
                return y.Price.CompareTo(x.Price);
            }
        }
    }

    class Book: IComparable<Book>
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

        public int CompareTo(Book? other)
        {
            if (other.Price.CompareTo(this.Price) != 0)
            {
                return this.Price.CompareTo(other.Price);
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> konyvek =
            new List<Book>
            {
                new Book("Egri Csillagok", "Gárdonyi Géza", 2001, 1040),
                new Book("Biblia", "Isten", 0, 1040),
                new Book("Fortnite", "Epic Games", 2013, 3000),
                new Book("Minecraft Tutorial", "Mojang", 2009, 1880),
                new Book("My War", "Funny Dude", 1939, 911)

            };

            foreach (Book book in konyvek)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("--------");

            konyvek.Sort();

            foreach (Book book in konyvek)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("--------");

            konyvek.Sort(new BookYearCompaprer());

            foreach (Book book in konyvek)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("--------");
            Dictionary<string, Book> bookDictionary = new Dictionary<string, Book>();
            foreach (Book book in konyvek) 
            {
                bookDictionary.Add(book.Title, book);
            }

            string bookTitle = Console.ReadLine().Trim();

            if(bookDictionary.ContainsKey(bookTitle))
            {
                Console.WriteLine(bookDictionary[bookTitle]);
            }
            else
            {
                Console.WriteLine("Nincs ilyen könyv a rendszerben.");
            }
        }
    }
}
