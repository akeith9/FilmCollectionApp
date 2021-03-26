using FilmCollectionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollectionApp.Models
{
    //creating inheritable context for the books db
    public class FilmsContext : DbContext
    {
        public FilmsContext (DbContextOptions<FilmsContext> options) : base (options)
        {

        }

        public DbSet<Films> Films { get; set; }

    }
}
