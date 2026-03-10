namespace WordGuesser
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] words = ["fuvola", "csirke", "adatok", "asztal", "fogoly", "bicska","farkas", "almafa", "babona", "gerinc", "dervis", "bagoly", "ecetes", "angyal", "boglya"];
			List<char> guess = [];
			Random rnd = new();
			int num = rnd.Next(15);
			int pos = num;
			string identical = words[pos];
			Input:
				string user = Console.ReadLine();
			if(user.Length > 0)
			{
				if(user != "stop")
				{
					if(user.Length > identical.Length)
					{
						while(user.Length > identical.Length)
						{
							user = user.Remove(user.Length-1);
						}
					}
					while(user.Length < identical.Length)
					{
						user += " ";
					}
					for(int i = 0; i < identical.Length; i++)
					{
						for(int j = 0; j < user.Length;j++)
						{
							while (guess.Count >= user.Length)
							{
								guess.RemoveAt(0);
							}
							if (user[j] == identical[i])
							{
								//Console.Write(user[i]);
								guess.Add(user[j]);
								if (guess[i] == '.')
								{
									guess[i] = user[j];
								}
							}
							else
							{
								//Console.Write(".");
								guess.Add('.');
								if (guess[i] == user[j])
								{

								}
							}
							i++;
						}
					}
				}
				else if(user == "stop")
				{
					goto Stop;
				}
				foreach (var item in guess)
				{
					Console.Write(item);
				}
				if (user == identical)
				{
					Console.WriteLine("\nNYERTÉL!!!!!!!!!!!!!");
				}
				Console.WriteLine("\n");
				goto Input;
			}
			else
			{
				Console.WriteLine("Nem írtál semmit!");
			}
			Stop:
				Environment.Exit(0);
			Console.ReadKey();
		}
	}
}
