using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager : DbContext
    {
        public DbSet<Videogame> Videogames { get; set; }

    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DatabaseVideogame;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}