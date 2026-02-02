using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_filmes
{
    internal class Stab
    {
        [Key]public int Fazon { get; set; }
        public int Munkakor { get; set; } // 1 – Rendező, 2 – Operatőr, 3 – Forgatókönyvíró, 4 – Író, 5 – Zeneszerző, 6 – Főszereplő, 7 – Szinkronszínész
        public int Alkazon { get; set; }
    }
}
