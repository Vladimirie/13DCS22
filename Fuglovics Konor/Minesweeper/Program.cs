using System.Drawing;

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
	internal class Field
	{
		public bool IsBomb
		{
			get;
			set;
		}
		public bool IsFlagged
		{
			get;
			set;
		}
		public int PosX
		{
			get;
			set;
		}
		public int PosY
		{
			get;
			set;
		}
		public Field(bool isbomb, bool isflagged, int posx, int posy)
		{
			IsBomb = isbomb;
			IsFlagged = isflagged;
			PosX = posx;
			PosY = posy;
		}
		public override string ToString()
		{
			return $"{PosX},{PosY}";
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
			string? setupdiff = Console.ReadLine();
			string d = setupdiff;
			List<Field> area = [];
			Dictionary<string, MineField> difficulty = [];
			difficulty.Add("easy", new MineField(8, 8, 10));
			difficulty.Add("normal", new MineField(16, 16, 40));
			difficulty.Add("hard", new MineField(40, 16, 99));
			void CreateField()
			{
				Console.Clear();
				foreach (var point in difficulty)
				{
					if(point.Key == setupdiff)
					{
						for (int y = 0; y < point.Value.SizeY; y++)
						{
							for (int x = 0; x < point.Value.SizeX; x++)
							{
								area.Add(new Field(false, false, x, y));
							}
						}
					}
				}
				foreach(var bomb in area)
				{
					foreach(var a in difficulty)
					{
						int b = a.Value.Bombs;
						if(a.Key == setupdiff)
						{
							for (int y = 0; y < a.Value.SizeY; y++)
							{
								for (int x = 0; x < a.Value.SizeX; x++)
								{
									if(b != 0 && x != 7 && y != 7)
									{
										Random rnd = new();
										int rand = rnd.Next(0,10);
										if(rand == 1)
										{
											if(x == bomb.PosX && y == bomb.PosY)
											{
												bomb.IsBomb = true;
											}
											b -= 1;
										}
									}
								}
							}
						}
					}
				}
			}
			void DisplayScreen()
			{
				Console.Clear();
				bool ib = false;
				foreach (var point in difficulty)
				{
					if(point.Key == d)
					{
						for (int y = 0; y < point.Value.SizeY; y++)
						{
							for (int x = 0; x < point.Value.SizeX && x < area.Count; x++)
							{
								if (area[x].IsBomb == true)
								{
									ib = true;
								}
								else
								{
									ib = false;
								}
								if (ib == true)
								{
									Console.Write("×");
								}
								else
								{
									Console.Write("Π");
								}
							}
							Console.Write("\n");
						}
					}
				}
			}
			CreateField();
			DisplayScreen();
			string inputpos = Console.ReadLine();
			string posinput = $"{inputpos[0]},{inputpos[1]}";
			string setflag = $"{posinput} flag";
			Console.ReadKey();
        }
    }
}
