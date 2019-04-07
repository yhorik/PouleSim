using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouleSim.Objects
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Offense { get; set; }
        public int Defense { get; set; }
       // public List<long> Players { get; set; }
        public string Players { get; set; }
    }
}
