using Microsoft.EntityFrameworkCore;
using SuperHeroesAPI.Data;
using SuperHeroesAPI.Data.Models;
using SuperHeroesAPI.Interfaces;

namespace SuperHeroesAPI.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly HeroDbContext _heroDbContext; 
        
        public SuperHeroRepository(HeroDbContext heroDbContext)
        {
            _heroDbContext = heroDbContext;
        }

        public async Task<SuperHero> CreateSuperHeroAsync(SuperHero superhero)
        {
            _heroDbContext.SuperHeroes.Add(superhero);
            await _heroDbContext.SaveChangesAsync();
            return superhero; 
        }

        public async Task<SuperHero> DeleteSuperHeroByIdAsync(int id)
        {
            var hero= await _heroDbContext.SuperHeroes.FindAsync(id);
            if (hero != null)
            {
                _heroDbContext.SuperHeroes.Remove(hero);
                await _heroDbContext.SaveChangesAsync();
            }

            return hero;
        }


        public async Task<List<SuperHero>> GetAllSuperHeroesAsync()
        {
            return await _heroDbContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero> GetSuperHeroByIdAsync(int id)
        {
            var hero = await _heroDbContext.SuperHeroes.FindAsync(id);

            return await _heroDbContext.SuperHeroes.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<SuperHero> UpdateSuperHeroAsync(SuperHero superhero)
        {
            var DbSuperhero = await _heroDbContext.SuperHeroes.FindAsync(superhero.Id);

            DbSuperhero.HeroName = superhero.HeroName;
            DbSuperhero.Franchise = superhero.Franchise;
            DbSuperhero.SuperPowers = superhero.SuperPowers;
            DbSuperhero.Image = superhero.Image;
            await _heroDbContext.SaveChangesAsync();
            return DbSuperhero;
            

                /*
            _heroDbContext.SuperHeroes.Update(superhero);
            await _heroDbContext.SaveChangesAsync();
            return superhero;
           */
            
        }
    }
}
