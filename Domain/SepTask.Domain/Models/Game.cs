
namespace SepTask.Domain.Models
{
    public class Game
    {
        private Game()
        {
            
        }
        public Game(string name, Genre genre, decimal price, DateOnly releaseDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Genre = genre;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public Guid Id { get;private set; }
        public string Name { get; private set; }
        public Genre Genre { get; private set; }
        public decimal Price { get; private set; }
        public DateOnly ReleaseDate { get; private set; }

        public Game ChangeName(string name) 
        {
            Name = name;
            return this;
        }
        public Game ChangeGenre(Genre genre)
        {
            Genre = genre;
            return this;
        }
        public Game ChangePrice(decimal price)
        {
            Price = price;
            return this;
        }
        public Game ChangeReleaseDate(DateOnly releaseDate)
        {
            ReleaseDate = releaseDate;
            return this;
        }
    }
}
