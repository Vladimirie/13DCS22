<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Art
{
	internal class Program
	{
		static void Main(string[] args)
		{
			for(int i=0;i<20;i++)
			{
				Thread.Sleep(50);
				Console.Write("-");
			}
			Console.Write("\n");
			int eyes = 0;
			int mouth = 0;
			for (int i = 0; i<4; i++)
			{
				Thread.Sleep(50);
				eyes++;
				mouth++;
				if(eyes == 2)
				{
					Console.WriteLine("|    0        0    |");
				}
				if (mouth == 3)
				{
					Console.WriteLine("|        w         |");
				}
				Console.WriteLine("|                  |");
			}
			for (int i = 0; i<20; i++)
			{
				Thread.Sleep(50);
				Console.Write("-");
			}
			Console.WriteLine("\nSzia! :3");
			Console.ReadKey();
		}
	}
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Art
{
	internal class Program
	{
		static void Main(string[] args)
		{
			for(int i=0;i<20;i++)
			{
				Thread.Sleep(50);
				Console.Write("-");
			}
			Console.Write("\n");
			int eyes = 0;
			int mouth = 0;
			for (int i = 0; i<4; i++)
			{
				Thread.Sleep(50);
				eyes++;
				mouth++;
				if(eyes == 2)
				{
					Console.WriteLine("|    0        0    |");
				}
				if (mouth == 3)
				{
					Console.WriteLine("|        w         |");
				}
				Console.WriteLine("|                  |");
			}
			for (int i = 0; i<20; i++)
			{
				Thread.Sleep(50);
				Console.Write("-");
			}
			Console.WriteLine("\nSzia! :3");
			Console.ReadKey();
		}
	}
}
>>>>>>> 508682966dc1c50aeb4017a64c1f9d921eaa4e6d
