using SuperHeroesAPI.Data.Models;

namespace SuperHeroesAPI.Interfaces
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAllSuperHeroesAsync(); 
        Task<SuperHero> GetSuperHeroByIdAsync(int id);
        Task<SuperHero> CreateSuperHeroAsync(SuperHero superhero); 
        Task<SuperHero> UpdateSuperHeroAsync(SuperHero superhero);
        Task<SuperHero> DeleteSuperHeroByIdAsync(int id);

    }
}
