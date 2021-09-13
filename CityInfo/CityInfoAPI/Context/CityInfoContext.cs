using CityInfoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Context
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(new City()
                {
                    Id = 1,
                    Name = "New Yourk City",
                    Description = "The one with that big park.",

                },
                 new City()
                 {
                     Id = 2,
                     Name = "Antwerpy",
                     Description = "The one with the cathedral that was never really finished",

                 },
                  new City()
                  {
                      Id = 3,
                      Name = "Paris",
                      Description = "The one with that big tower.",

                  });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                        new PointOfInterest()
                        {
                            Id = 5,
                            CityId = 3,
                            Name = "Eifel Tower",
                            Description = "A wrough iron lettuce tower on the camp de mars"
                        },
                          new PointOfInterest()
                          {
                              Id = 6,
                              CityId = 3,
                              Name = "The Louvre",
                              Description = "The world's largest meseum."
                          },
                           new PointOfInterest()
                           {
                               Id = 2,
                               CityId = 1,
                               Name = "Empire State Building",
                               Description = "The most visited building in US."
                           },
                          new PointOfInterest()
                          {
                              Id = 1,
                              CityId = 1,
                              Name = "Central Park",
                              Description = "The most visited park in US."
                          },
                           new PointOfInterest()
                           {
                               Id = 4,
                               CityId = 2,
                               Name = "Antwerp Central Station",
                               Description = "The finest example of railway"
                           },
                          new PointOfInterest()
                          {
                              Id = 3,
                              CityId = 2,
                              Name = "Cathedral of Our Lady",
                              Description = "A gothic cathedral."
                          }
                          );

            base.OnModelCreating(modelBuilder);
        }
    }
}
