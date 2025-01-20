using System.ComponentModel.DataAnnotations;

namespace GameStore.FrontEnd.Models
{
    public class GameDetails
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        [Required]
        public Guid GenreId { get; set; }
        [Range(1, 100)]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
