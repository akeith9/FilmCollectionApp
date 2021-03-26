using FilmCollectionApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollectionApp.Models
{
    public class SeedData
    {
        //creating method to ensure that databse is populated
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            FilmsContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<FilmsContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if not populated, then insert this data
            if(!context.Films.Any())
            {
                context.Films.AddRange(

                    new Films
                    {
                        Category = "Sci-Fiction",
                        Title = "Star Wars: The Empire Strikes Back",
                        Year = 1985,
                        Director = "George Lucas",
                        Rating = "10",
                        Edited = false,
                        Lent = "No",
                        Notes = "Classic"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
