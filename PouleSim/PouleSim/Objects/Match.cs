using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouleSim.Objects
{
    public class Match
    {
        public static Random rand = new Random();

        public long Id { get; set; }
        public long TeamOne { get; set; }
        public long TeamTwo { get; set; }
        public int ScoreOne { get; set; }
        public int ScoreTwo { get; set; }

        public void Simulate(Team t1, Team t2)
        {
            TeamOne = t1.Id;
            TeamTwo = t2.Id;

            ScoreOne = (t1.Offense - t2.Defense+ Match.rand.Next() % 24-8)/4;
            ScoreTwo = (t2.Offense - t1.Defense+ Match.rand.Next() % 24-8)/4;
            if (ScoreOne < 0) ScoreOne = 0;
            if (ScoreTwo < 0) ScoreTwo = 0;
        }
    }
}
