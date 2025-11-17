namespace Minesweeper
{
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
            List<MineField> easy = [new MineField(8,8,10)];
			List<MineField> normal = [new MineField(16,16,40)];
			List<MineField> hard = [new MineField(40,16,99)];

			foreach(var field in normal)
			{
				for(int y = 0; y < field.SizeY;y++)
				{
					for(int x = 0; x < field.SizeX;x++)
					{
						Console.Write("Π");
					}
					Console.Write("\n");
				}
			}
			Console.ReadKey();
        }
    }
}
