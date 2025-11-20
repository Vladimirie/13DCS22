using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARVEL_RIVELS__REAL_
{
    class Jelenet
    {
        public string Film { get; set; }
        public int Sorszam { get; set; }

        public string[] Heros { get; set; }

        public Jelenet(string cim, int sorszam, string[] heros)
        {
            Film = cim;
            Sorszam = sorszam;
            Heros = heros;
        }
    }
}
