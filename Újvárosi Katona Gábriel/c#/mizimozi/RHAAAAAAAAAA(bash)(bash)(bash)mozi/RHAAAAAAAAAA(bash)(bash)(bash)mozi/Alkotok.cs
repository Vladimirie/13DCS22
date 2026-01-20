using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RHAAAAAAAAAA_bash__bash__bash_mozi
{
    internal class Alkotok
    {

        [Key] public int Alkotoazon { get; set; }
        public string Nev { get; set; }
        public DateTime Szuletett { get; set; }
        public DateTime Elhunyt { get; set; }

    }
}
