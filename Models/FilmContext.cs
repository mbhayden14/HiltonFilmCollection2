using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonFilmCollection2.Models
{
    //Model that includes the dbset for the FilmDb database
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        { }

        public DbSet<FilmItem> Films { get; set; }
    }
}
