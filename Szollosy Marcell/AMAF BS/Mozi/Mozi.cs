class Mozi : IComparable<Mozi>
{
    public Mozi(string film_cím, string műfaj, int korhatar, int kezdési_idő)
    {
        Film_cím = film_cím;
        Műfaj = műfaj;
        Korhatar = korhatar;
        Kezdési_idő = kezdési_idő;
    }

    public string Film_cím { get; set; }
    public string Műfaj { get; set; }
    public int Korhatar { get; set; }
    public int Kezdési_idő { get; set; }

    public int CompareTo(Mozi other)
    {
        int cmp = this.Kezdési_idő.CompareTo(other.Kezdési_idő);
        if (cmp != 0)
        {
            return cmp;
        }

        cmp = other.Korhatar.CompareTo(this.Korhatar);
        if (cmp != 0)
        {
            return cmp;
        }
        return this.Film_cím.CompareTo(other.Film_cím);
    }

    public override string ToString()
    {
        return $"{Film_cím} ({Műfaj}): {Kezdési_idő}";
    }
}
