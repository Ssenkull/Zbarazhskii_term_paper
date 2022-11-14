using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Stadium
    {
        public Guid StadiumId { get; set; }
        public string StadiumName { get; set; }
        public int NumberOfSeats { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerSeat { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
