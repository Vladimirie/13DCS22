namespace BookCatalog
{
	internal class Catalog
	{
		public string Title { get; set; }
		public int PageCount { get; set; }
		public int RelYear { get; set; }
		public string Genre{ get; set; }
		public Catalog(string title, int pagecount, int relyear, string genre)
		{
			Title=title;
			PageCount=pagecount;
			RelYear=relyear;
			Genre=genre;
		}
		public override string ToString()
		{
			return Title;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> books = [];
			SortedDictionary<string, List<Catalog>> result = [];
			foreach(var file in File.ReadAllLines("konyvek.txt"))
			{
				string[] line = file.Split(";");
				books.Add(new Catalog(line[0], int.Parse(line[1]), int.Parse(line[2]), line[3]));
				if(!result.ContainsKey(line[3]))
				{
					result.Add(line[3], []);
				}
				result[line[3]].Add(new Catalog(line[0], int.Parse(line[1]), int.Parse(line[2]), line[3]));
			}
			foreach(var genre in result.Keys)
			{
				Console.WriteLine($"{genre}:");
				Console.WriteLine(string.Join("\n",result[genre]));
			}
			Console.ReadKey();
        }
    }
}
