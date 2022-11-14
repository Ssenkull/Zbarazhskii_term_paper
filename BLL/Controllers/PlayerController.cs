using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class PlayerController
    {
        private readonly FMContext _context = new FMContext();
        public List<Player> GetAllPlayers()
        {
            var players = _context.Players.Include(p => p.Team).ToList();
            return players;
        }

        public Player GetPlayerByName(string fname, string sname)
        {
            var player = _context.Players.Include(p => p.Team).SingleOrDefault(p => p.FirstName == fname && p.LastName == sname);
            return player;
        }

        public void AddPlayer(string fname, string lname, DateTime dateOfBirth, PlayerStatus status, HealthStatus healthStatus, decimal salary, string teamname)
        {
            var team = _context.Teams.SingleOrDefault(x => x.TeamName == teamname);
            var player = new Player
            {
                FirstName = fname,
                LastName = lname,
                DateOfBirth = dateOfBirth,
                Salary = salary,
                HealthStatus = healthStatus,
                PlayerStatus = status,
                TeamId = team.TeamId
            };
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void EditPlayer(string originalName, string originalSurname, string fname, string lname, DateTime dateOfBirth, PlayerStatus status, HealthStatus healthStatus, decimal salary, string teamname)
        {
            var team = _context.Teams.SingleOrDefault(x => x.TeamName == teamname);
            var player = GetPlayerByName(originalName, originalSurname);
            player.FirstName = fname;
            player.LastName = lname;
            player.DateOfBirth = dateOfBirth;
            player.Salary = salary;
            player.HealthStatus = healthStatus;
            player.PlayerStatus = status;
            player.TeamId = team.TeamId;

            _context.Entry(player).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePlayer(string name, string surname)
        {
            var player = GetPlayerByName(name, surname);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public bool PlayerExist(string fname, string lname)
        {
            var players = _context.Players.Where(x => x.FirstName == fname && x.LastName == lname).ToList();
            return players.Any();
        }

        public List<Player> SearchByNameOrSurname(string name)
        {
            var players = _context.Players.Where(x => x.FirstName == name || x.LastName == name).ToList();
            return players;
        }
    }
}
