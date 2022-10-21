namespace SuperHeroesAPI.Data.Models
{
    public class SuperHero
    {
        public int Id { get; set; } 
        public string? HeroName{ get; set; }
        public string? Franchise { get; set; } 
        public string? SuperPowers { get; set; }
        public string? Image { get; set; }
    }
}
