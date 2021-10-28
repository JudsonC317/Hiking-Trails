using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HikingTrails.Data;
using System;
using System.Linq;

namespace HikingTrails.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Trail.Any())
                {
                    return;   // DB has been seeded
                }

                context.Trail.AddRange(
                    new Trail
                    {
                        trailName = "Cat Rock",
                        rating = 5,
                        review = "Good view at the top, if you're able to make the steep climb."
                    },

                    new Trail
                    {
                        trailName = "Piney Run",
                        rating = 4,
                        review = "Cool lake and birdhouse."
                    }

                );
                context.SaveChanges();
            }
        }
    }
}