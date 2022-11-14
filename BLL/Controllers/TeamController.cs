using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class TeamController
    {
        private readonly FMContext _context = new FMContext();

        public List<Team> GetAllTeams()
        {
            var teams = _context.Teams.Include(t => t.Players).Include(t => t.Games).ToList();

            return teams;
        }

        public Team GetTeamByName(string name)
        {
            var team = _context.Teams.Include(t => t.Players).Include(t => t.Games).SingleOrDefault(x => x.TeamName == name);
            return team;
        }

        public void AddTeam(string teamname)
        {
            var team = new Team
            {
                TeamName = teamname,
                Players = new List<Player>(),
                Games = new List<Game>()
            };
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void EditTeam(string originalName, string teamname)
        {
            var team = GetTeamByName(originalName);
            team.TeamName = teamname;
            _context.Entry(team).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeam(string teamname)
        {
            var team = GetTeamByName(teamname);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        public bool TeamExist(string name)
        {
            var teams = _context.Teams.Where(x => x.TeamName == name).ToList();
            return teams.Count > 0 ? true : false;
        }
    }
}
