using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_filmes
{
    internal class Film
    {
        [Key]public int Filmazon { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public string Szines { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
    }
}
