using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class GameController
    {
        private readonly FMContext _context = new FMContext();

        public List<Game> GetAllGames()
        {
            var games = _context.Games.ToList();
            return games;
        }

        public Game GetGameByName(string name)
        {
            var game = _context.Games.SingleOrDefault(x => x.GameTitle == name);
            return game;
        }

        public void AddGame(int viewers, Result result, string teamone, string teamtwo, string stadiumName, DateTime date)
        {
            var team = _context.Teams.SingleOrDefault(x => x.TeamName == teamone);
            var opponents = _context.Teams.SingleOrDefault(x => x.TeamName == teamtwo);
            var stadium = _context.Stadiums.SingleOrDefault(x => x.StadiumName == stadiumName);
            var gameToAdd = new Game
            {
                GameTitle = team.TeamName+"-"+opponents.TeamName,
                StadiumId = stadium.StadiumId,
                NumberOfViewers = viewers,
                ResultOfTheGame = result,
                TeamId = team.TeamId,
                OpponentsId = opponents.TeamId,
                GameDate = date
            };
            _context.Games.Add(gameToAdd);
            _context.SaveChanges();
        }

        public void EditGame(string gametitle, string stadiumname, int viewers, Result result, string teamone, string teamtwo, DateTime date)
        {
            var game = GetGameByName(gametitle);
            var team = _context.Teams.SingleOrDefault(x => x.TeamName == teamone);
            var opponents = _context.Teams.SingleOrDefault(x => x.TeamName == teamtwo);
            var stadium = _context.Stadiums.SingleOrDefault(x => x.StadiumName == stadiumname);

            game.StadiumId = stadium.StadiumId;
            game.NumberOfViewers = viewers;
            game.ResultOfTheGame = result;
            game.TeamId = team.TeamId;
            game.OpponentsId = opponents.TeamId;
            game.GameTitle = teamone + "-" + teamtwo;
            game.GameDate = date;

            _context.Entry(game).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGame(string gametitle)
        {
            var game = GetGameByName(gametitle);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public bool GameExist(string name)
        {
            var games = _context.Games.Where(x => x.GameTitle == name).ToList();
            return games.Any();
        }

        public List<Game> SearchByDateAndOp(DateTime date, string title)
        {
            var game = _context.Games.Where(x => x.GameDate == date && x.GameTitle == title).ToList();
            return game;
        }

        public List<Game> Sort(int option)
        {
            var list = GetAllGames();
            if (option == 1)
            {
                return list.OrderBy(x => x.GameDate).ToList();   
            }
            else
            {
                return list.OrderBy(x => (int)(x.ResultOfTheGame)).ToList();
            }
        }
    }
}
