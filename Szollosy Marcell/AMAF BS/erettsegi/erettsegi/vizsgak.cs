using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erettsegi
{
    public class Vizsgak
    {
        public int Id { get; set; }
        public string Bizottsag { get; set; }
        public string Vizsgatargy { get; set; }
        public int VizsgazoId { get; set; }

        public string TanarId { get; set; }
    }
}
