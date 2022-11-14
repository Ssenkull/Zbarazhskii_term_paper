using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
        public HealthStatus HealthStatus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }
    }

    public enum PlayerStatus
    {
        Active,
        Inactive
    }
    public enum HealthStatus
    {
        Healthy,
        Injured
    }
}
