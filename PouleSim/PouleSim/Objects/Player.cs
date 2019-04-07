using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouleSim.Objects
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Shoot { get; set; }
        public int Pass { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Aggression { get; set; }
        public int Foot { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
