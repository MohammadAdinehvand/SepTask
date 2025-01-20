namespace GameStore.FrontEnd.Models
{
    public class GameSummary
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
