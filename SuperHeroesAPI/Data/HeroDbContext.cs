using Microsoft.EntityFrameworkCore;
using SuperHeroesAPI.Data.Models;

namespace SuperHeroesAPI.Data
{
    public class HeroDbContext:DbContext
    {

        public HeroDbContext(DbContextOptions<HeroDbContext> options):base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
      


    }
}
