using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Könyvtár
{
    class Konyv : IComparable<Konyv>
    {
        public string Cim { get; set; }
        public int Oldalszal { get; set; }
        public int KiadasiEv { get; set; }
        public string Reszleg { get; set; }

        public Konyv(string cim, int oldalszal, int kiadasiEv, string reszleg)
        {
            Cim = cim;
            Oldalszal = oldalszal;
            KiadasiEv = kiadasiEv;
            Reszleg = reszleg;
        }



        public int CompareTo(Konyv other)
        {
            if (this.KiadasiEv != other.KiadasiEv)
            {
                return other.KiadasiEv.CompareTo(this.KiadasiEv);
            }
            else if (this.Oldalszal != other.Oldalszal)
            {
                return this.Oldalszal.CompareTo(other.Oldalszal);
            }
            else
            {

                return this.Cim.CompareTo(other.Cim);
            }

        }
    }
}
