using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_filmes
{
    internal class Alkoto
    {
        [Key] public int Alkotoazon{ get; set; }
        public string Nev { get; set; }
        public string Szuletett{ get; set; }
        public string Elhunyt{ get; set; }
    }
}
