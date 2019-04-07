using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouleSim.Objects
{
    public class PouleStanding
    {
        public long Id { get; set; }
        public long Team { get; set; }
        public int Points { get; set; }
        public int GoalDifferential { get; set; }
        public int GoalsScored { get; set; }
        public List<long> TeamsBeat = new List<long>();

        public void AddMatch(Match m,bool home)
        {
            int gd = m.ScoreOne - m.ScoreTwo;
            if (home)
            {
                
                if(gd > 0)
                {
                    Points += 3;
                    TeamsBeat.Add(m.TeamTwo);
                }
                else if(gd == 0)
                {
                    Points += 1;
                }
                GoalDifferential += gd;
                GoalsScored += m.ScoreOne;
            }
            else
            {
                if (gd < 0)
                {
                    Points += 3;
                    TeamsBeat.Add(m.TeamOne);
                }
                else if (gd == 0)
                {
                    Points += 1;
                }
                GoalDifferential -= gd;
                GoalsScored += m.ScoreTwo;
            }
        }
    }
}
