using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class StadiumController
    {
        private readonly FMContext _context = new FMContext();

        public List<Stadium> GetAllStadiums()
        {
            var stadiums = _context.Stadiums.Include(s => s.Games).ToList();
            return stadiums;
        }

        public Stadium GetStadiumByName(string name)
        {
            var stadium = _context.Stadiums.Include(s => s.Games).SingleOrDefault(s => s.StadiumName == name);
            return stadium;
        }

        public void AddStadium(string name, int numberofseats, decimal priceperseat)
        {
            var stadium = new Stadium
            {
                StadiumName = name,
                NumberOfSeats = numberofseats,
                PricePerSeat = priceperseat,
                Games = new List<Game>()
            };
            _context.Stadiums.Add(stadium);
            _context.SaveChanges();
        }

        public void EditStadium(string originalname, string name, int numberofseats, decimal priceperseat)
        {
            var stadium = GetStadiumByName(originalname);
            stadium.StadiumName = name;
            stadium.NumberOfSeats = numberofseats;
            stadium.PricePerSeat = priceperseat;
            _context.Entry(stadium).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStadium(string name)
        {
            var stadium = GetStadiumByName(name);
            _context.Stadiums.Remove(stadium);
            _context.SaveChanges();
        }

        public bool StadiumExist(string name)
        {
            var stadiums = _context.Stadiums.Where(x => x.StadiumName == name).ToList();
            return stadiums.Any();
        }
    }
}
