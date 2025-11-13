namespace Mozi
{
	internal class Theater
	{
		public string Name { get; set; }
		public string Genre { get; set; }
		public int AudienceAge { get; set; }
		public int StartInSecs { get; set; }
		public Theater(string name, string genre, int audienceage, int startinsecs)
		{
			Name = name;
			Genre = genre;
			AudienceAge = audienceage;
			StartInSecs = startinsecs;
		}
		public override string ToString()
		{
			return $"{Name} ({Genre}): {StartInSecs}";
		}
		/*public int CompareTo(Theater? other)
		{
			if (other.StartInSecs.CompareTo(this.StartInSecs)==0)
			{
				if (other.AudienceAge.CompareTo(this.AudienceAge)==0)
				{
					return this.Name.CompareTo(other.Name);
				}
				return other.AudienceAge.CompareTo(this.AudienceAge);
			}
			return this.StartInSecs.CompareTo(other.StartInSecs);
		}*/
	}
}
