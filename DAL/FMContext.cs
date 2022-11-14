using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FMContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7SP73R7;Database=FootballManager_Db;Trusted_connection = true;MultipleActiveResultSets=true; encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Game>().HasOne(x => x.Team).WithMany().IsRequired(false).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
