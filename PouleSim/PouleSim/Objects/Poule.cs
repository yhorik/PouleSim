using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouleSim.Objects
{
    public class Poule
    {
        public List<Match> Matches { get; set; }
        public List<PouleStanding> Standings { get; set; }

        public void Simulate(List<Team> teams)
        {
            Matches = new List<Match>();
            Match match;
            int teamCount = teams.Count;
            int matchCount = 0;
            Standings = new List<PouleStanding>();
            for (int i = 0; i < teamCount; i++)
            {
                PouleStanding ps = new PouleStanding
                {
                    Id = i,
                    Team = teams[i].Id
                };
                Standings.Add(ps);
            }
            for (int i = 0; i < teamCount; i++)
            {
                Standings[i].Team = teams[i].Id;
                for (int j = i + 1; j < teamCount; j++)
                {
                    matchCount++;
                    match = new Match
                    {
                        Id = matchCount
                    };
                    match.Simulate(teams[i],teams[j]);
                    Matches.Add(match);
                    Standings[i].AddMatch(match,true);
                    Standings[j].AddMatch(match,false);
                }
            }
            Standings.Sort(new PouleSort());
        }

        public class PouleSort : IComparer<PouleStanding>
        {
            public PouleSort() { }

            public int Compare(PouleStanding s1, PouleStanding s2)
            {
                if(s1.Points > s2.Points)
                {
                    return -1;
                }else if(s1.Points < s2.Points)
                {
                    return 1;
                }
                else
                {
                    if (s1.GoalDifferential > s2.GoalDifferential)
                    {
                        return -1;
                    }
                    else if(s1.GoalDifferential < s2.GoalDifferential)
                    {
                        return 1;
                    }
                    else
                    {
                        if (s1.GoalsScored > s2.GoalsScored)
                        {
                            return -1;
                        }
                        else if (s1.GoalsScored < s2.GoalsScored)
                        {
                            return 1;
                        }
                        else
                        {
                            if(s1.TeamsBeat.IndexOf(s2.Team) > s2.TeamsBeat.IndexOf(s1.Team))
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    
                }
            }
        }
    }
}
