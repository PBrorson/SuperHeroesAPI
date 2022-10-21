using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroesAPI.Data;
using SuperHeroesAPI.Data.Models;
using SuperHeroesAPI.Interfaces;

namespace SuperHeroesAPI.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
      
        private readonly ISuperHeroRepository _superheroes;

        public SuperHeroController(ISuperHeroRepository heroes)
        {
            _superheroes = heroes;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            
            return Ok(await _superheroes.GetAllSuperHeroesAsync());
        }

        [HttpPost] 
        public async Task<IActionResult> Post(SuperHero superHero)
        {
          
            return Ok(await _superheroes.CreateSuperHeroAsync(superHero));
            
        }

       
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult>GetHeroes(int id)
        {
            try
            {
                var hero = await _superheroes.GetSuperHeroByIdAsync(id);
                if (hero == null)
                    return NotFound();
                return Ok(hero); 
            }
            catch (Exception)
            {
                return NotFound();
            }
        
          
        }
       
        [HttpPut]
        public async Task<IActionResult> Put(SuperHero updatedSuperhero)
        {

            var hero = await _superheroes.GetAllSuperHeroesAsync();
            if (hero is null)
            {
                return NotFound();
            }
            return Ok(await _superheroes.UpdateSuperHeroAsync(updatedSuperhero));
           

        }
       
       
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            try
            {
                var hero = await _superheroes.GetSuperHeroByIdAsync(id);

                if (hero == null)
                {
                    return NotFound();
                }


                return await _superheroes.DeleteSuperHeroByIdAsync(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
