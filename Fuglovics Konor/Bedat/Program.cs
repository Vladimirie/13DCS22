namespace Bedat
{
	internal class Gate
	{
		public string ID {get;set;}
		public TimeSpan Time {get;set;}
		public int Type {get;set;}
		public Gate(string id, TimeSpan time, int type)
		{
			ID=id;
			Time=time;
			Type=type;
		}
		public override string ToString()
		{
			return $"ID: {ID}, Idô: {Time.Hours}ó {Time.Minutes}p Tevékenység: {Type}";
		}
	}
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Gate> list = [];
			foreach(var file in File.ReadAllLines("bedat.txt"))
			{
				string[] line = file.Split(" ");
				string[] t = line[1].Split(":");
				list.Add(new Gate(line[0], new TimeSpan(int.Parse(t[0]), int.Parse(t[1]), 0), int.Parse(line[2])));
			}
			for(int i = 0; i < list.Count; i++)
			{
				if(i == 0)
				{
					Console.WriteLine($"Az elsô tanuló {list[i].Time}-kor lépett be.");
				}
				if(i == list.Count-1)
				{
					Console.WriteLine($"Az utolsó tanuló {list[i].Time}-kor lépett ki.");
				}
			}
			TimeSpan time1 = new TimeSpan(7,50,0);
			TimeSpan time2 = new TimeSpan(8,15,0);
			foreach(var item in list)
			{
				if(item.Time > time1 && item.Time < time2 && item.Type == 1)
				{
					File.WriteAllText("kesok.txt", item.ToString());
				}
			}
			File.OpenText("kesok.txt").Close();
			foreach(var item2 in File.ReadAllLines("kesok.txt"))
			{
				Console.WriteLine(item2);
			}
			int db = 0;
			foreach(var lunch in list)
			{
				if(lunch.Type == 3)
				{
					db++;
				}
			}
			Console.WriteLine($"{db} tanuló ebédelt");
			int book = 0;
			int lnch = 0;
			HashSet<Gate> hash = [];
			foreach(var compare in list)
			{
				if(compare.Type == 4)
				{
					hash.Add(compare.ID);
				}
			}
			Console.ReadKey();
        }
    }
}
