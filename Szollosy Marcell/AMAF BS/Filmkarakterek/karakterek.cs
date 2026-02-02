class karakterek
{
    public karakterek(string film_Címe, int jelenet_Sorszama, int v, string karakter)
    {
        Film_Címe = film_Címe;
        Jelenet_Sorszama = jelenet_Sorszama;
        Karakter = karakter;
    }

    public string Film_Címe { get; set; }
    public int Jelenet_Sorszama { get; set; }
    public string Karakter { get; set; }
}
