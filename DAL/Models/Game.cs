using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public DateTime GameDate { get; set; }
        public int NumberOfViewers { get; set; }
        public Result ResultOfTheGame { get; set; }
        public string GameTitle { get; set; }

        public Guid StadiumId { get; set; }

        public Guid TeamId { get; set; }

        public Guid OpponentsId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Team Opponents{ get; set; }
        public virtual Stadium Stadium { get; set; }

    }

    public enum Result
    {
        Victory,
        Loss,
        Draw,
        NotYetHeld
    }
}
