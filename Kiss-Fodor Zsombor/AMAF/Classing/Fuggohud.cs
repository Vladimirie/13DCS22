using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classing
{
    public class Fuggohud
    {
        public int Helyezes { get; set; }
        public string Nev { get; set; }
        public string Hely { get; set; }
        public string Orszag { get; set; }
        public int Hossz { get; set; }
        public int Ev { get; set; }

        public Fuggohud(int helyezes, string nev, string hely, string orszag, int hossz, int ev)
        {
            Helyezes = helyezes;
            Nev = nev;
            Hely = hely;
            Orszag = orszag;
            Hossz = hossz;
            Ev = ev;
        }
    }
}
