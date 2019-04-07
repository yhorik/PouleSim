using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PouleSim.Objects;
using System;


namespace PouleSim.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class SimController : ControllerBase
    {
        private readonly Random rand = new Random();

        private readonly DataContext _context;

        public SimController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Sim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        [HttpGet("teams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();

            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }

        [HttpGet("teams/generate")]
        public async Task<ActionResult<IEnumerable<Team>>> GenerateTeams()
        {
            if(_context.Teams.Count() > 0)
            {
                foreach (var entity in _context.Teams)
                    _context.Teams.Remove(entity);
            }
            for (int i = 0; i < 4; i++)
            {
                Team t = new Team { Name = "Team" + i, Offense = rand.Next() % 16, Defense = rand.Next() % 16 };
                _context.Teams.Add(t);
                t.Name = "Team" + t.Id;
            }
            _context.SaveChanges();
            var teams = await _context.Teams.ToListAsync();
            if (teams == null)
            {
                return NotFound();
            }
            
            return teams;
        }

        [HttpGet("match/{t1}-{t2}")]
        public async Task<ActionResult<Match>> SimulateMatch(long t1, long t2)
        {
            Match match = new Match();
            match.Simulate(_context.Teams.Find(t1),_context.Teams.Find(t2));
            return match;
        }

        [HttpGet("poule")]
        public async Task<ActionResult<Poule>> SimulatePoule()
        {
            Poule poule = new Poule();
            
            poule.Simulate(_context.Teams.ToList());
            return poule;
        }
    }
}