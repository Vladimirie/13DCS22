using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Függőhidal;
using Fuggohidak;

List<Fuggohid> hidak = new List<Fuggohid>();

namespace Fuggohidak
{
        public class Fuggohid
        {
            public int Helyezes { get; set; }
            public string Nev { get; set; }
            public string Hely { get; set; }
            public string Orszag { get; set; }
            public int Hossz { get; set; }
            public int AtadasEve { get; set; }

            public Fuggohid() { }   // 👈 EZ KELL

            public override string ToString()
            {
                return Nev;
            }
        }
 }



