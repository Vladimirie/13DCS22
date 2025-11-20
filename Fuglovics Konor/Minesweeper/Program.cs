namespace Minesweeper
{
	internal class Game
	{
		public string Difficulty
		{
			get;
			set;
		}
		public MineField Field
		{
			get;
			set;
		}
		public Game(string diff, MineField field)
		{
			Difficulty=diff;
			Field=field;
		}
	}
	internal class MineField
	{
		public int SizeX
		{
			get;
			set;
		}
		public int SizeY
		{
			get;
			set;
		}
		public int Bombs
		{
			get;
			set;
		}
		public MineField(int sizex, int sizey, int bombs)
		{
			SizeX=sizex;
			SizeY=sizey;
			Bombs=bombs;
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            void CreateField(string user)
			{
				MineField normal = new MineField(16, 16, 40);
				MineField hard = new MineField(40, 16, 99);
				Dictionary<string, MineField> difficulty = [];
				difficulty.Add("easy", new MineField(8,8,10));
				difficulty.Add("normal", new MineField(16,16,40));
				difficulty.Add("hard", new MineField(40,16,99));
				Console.Clear();
				foreach (var point in difficulty)
				{
					if(point.Key == user)
					{
						for (int y = 0; y < point.Value.SizeY; y++)
						{
							for (int x = 0; x < point.Value.SizeX; x++)
							{
								Console.Write("Π");
							}
							Console.Write("\n");
						}
					}
				}
			}
			string setupdiff = Console.ReadLine();
			CreateField(setupdiff);

			Console.ReadKey();
        }
    }
}
