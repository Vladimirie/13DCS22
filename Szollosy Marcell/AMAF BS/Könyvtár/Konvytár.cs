class Konyvtar
{
    public Konyvtar(string cím, int oldalszám, int kiadási_év, string részleg)
    {
        Cím = cím;
        Oldalszám = oldalszám;
        Kiadási_év = kiadási_év;
        Részleg = részleg;
    }

    public string Cím { get; set; }
    public int Oldalszám { get; set; }
    public int Kiadási_év { get; set; }
    public string Részleg { get; set; }
}