using Microsoft.EntityFrameworkCore;
using BeerCollection.API.Entities;

namespace BeerCollection.API.Context
{
    public class BeerContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerRating> BeerRatings { get; set; }

        public BeerContext(DbContextOptions<BeerContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>()
                .HasData(
                new Beer()
                {
                    Id = 1,
                    Name = "Tuborg",
                    Type = "Strong",
                    Rating=1
                },
                new Beer()
                {
                    Id = 2,
                    Name = "Kingfisher",
                    Type = "Premium",
                    Rating=1
                },
                new Beer()
                {
                    Id = 3,
                    Name = "Carlsberg",
                    Type = "Elephant",
                    Rating=1
                }
                );
            modelBuilder.Entity<BeerRating>()
                .HasData(
                new BeerRating()
                {
                    Id=1,
                    BeerId=1,
                    Rate = 3,
                    Description="Delicious"
                },
                new BeerRating()
                {
                    Id=2,
                    BeerId=1,
                    Rate = 5,
                    Description="Special"
                },
                new BeerRating()
                {
                    Id=3,
                    BeerId=2,
                    Rate = 3,
                    Description="Delicious"
                },
                new BeerRating()
                {
                    Id=4,
                    BeerId=2,
                    Rate = 5,
                    Description="Delicious"
                },
                new BeerRating()
                {
                    Id=5,
                    BeerId=3,
                    Rate = 3,
                    Description="Delicious"
                },
                new BeerRating()
                {
                    Id=6,
                    BeerId=3,
                    Rate = 3,
                    Description="Delicious"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
