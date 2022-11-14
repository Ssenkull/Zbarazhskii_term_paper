using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
