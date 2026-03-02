using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace autok
{
    internal class Auto
    {
        public int place {  get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int amount { get; set; }
        public int average { get; set; }

        public Auto(int place, string make, string model, int year, string color, int amount, int average) { 
            this.place = place;
            this.make = make;
            this.model = model;
            this.year = year;
            this.color = color;
            this.amount = amount;
            this.average = average;
        }

        public void Beolvas(List<Auto> list, string readable) {
            string[] falj = File.ReadAllLines(readable);

            for (int i = 1; i < falj.Length; i++) //így átugorjuk az első sort
            {
                string[] s = falj[i].Split(';');
                list.Add(new Auto(int.Parse(s[0]), s[1], s[2], int.Parse(s[3]), s[4], int.Parse(s[5]), int.Parse(s[6])));
            }
        }
    }
}
