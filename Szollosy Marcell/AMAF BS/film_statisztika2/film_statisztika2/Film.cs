using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStatisztika
{

    public class Film
    {

    public Film(int filmAzon, string cim, int ev, string szines, string mufaj, int hossz)
    {
        FilmAzon = filmAzon;
        Cim = cim;
        Ev = ev;
        Szines = szines;
        Mufaj = mufaj;
        Hossz = hossz;
     }
    
        public int FilmAzon { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public string Szines { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
    };
}
