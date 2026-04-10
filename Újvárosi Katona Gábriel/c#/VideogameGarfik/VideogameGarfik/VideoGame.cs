using System;
using System.Collections.Generic;
using System.Text;

namespace VideogameGarfik
{
    internal class VideoGame
    {

        public VideoGame(string nev, string konzol, string mufaj, string kiado, string fejleszto, double kritikusi_pontszam, double osszes_eladas, int kiadas_eve)
        {
            Nev = nev;
            Konzol = konzol;
            Mufaj = mufaj;
            Kiado = kiado;
            Fejleszto = fejleszto;
            Kritikusi_pontszam = kritikusi_pontszam;
            Osszes_eladas = osszes_eladas;
            Kiadas_eve = kiadas_eve;
        }

        public string Nev { get; set; }
        public string Konzol { get; set; }
        public string Mufaj { get; set; }
        public string Kiado { get; set; }
        public string Fejleszto { get; set; }
        public double Kritikusi_pontszam { get; set; }
        public double Osszes_eladas { get; set; }
        public int Kiadas_eve { get; set; }


    }
}
