using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_bullshit
{
    internal class Entity
    {
        //
        public string Name { get; set; }
        public string Species { get; set; }
        //public int Sex { get; set; }

        //Stats
        public int Level { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int CritChance { get; set; }
        public float Critmultiplier { get; set; }

        //Skills
        public int Strenght { get; set; }
        public int Toughness { get; set; }
        public int Inteligence { get; set; }
        public int Charisma { get; set; }
        public int Agility { get; set; }

        public Entity(string name, string species, int strenght, int toughness, int inteligence, int charisma, int agility)
        {
            Name = name;
            Species = species;
            Strenght = strenght;
            Toughness = toughness;
            Inteligence = inteligence;
            Charisma = charisma;
            Agility = agility;       
        }

        string[] GetSpeciesStat(string species) 
        {
            string[] speciesList = File.ReadAllLines("Species");
            string[] multipliers = {"1", "1", "1", "1"};

            bool foundOurSpecie = false;
            int i = 2;
            while (!foundOurSpecie && i < speciesList.Length)
            {
                string[] splitData = speciesList[i].Split(",");
                if (splitData[0] == species)
                {
                    foundOurSpecie = true;
                    multipliers = new string[] { splitData[1], splitData[2], splitData[3], splitData[4] };
                   
                }
                else
                {
                    i++;
                }
            }

            return multipliers;
        }

        void CalculateStats() 
        { 
            GetSpeciesStat(Species);
        }
    }
}
