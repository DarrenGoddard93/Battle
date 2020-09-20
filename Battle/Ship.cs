using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    public class Ship
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public char Symbol { get; set; }


        public Ship(string name, int length, char symbol)
        {
            Name = name;
            Length = length;
            Symbol = symbol;
        } 
    }
}
