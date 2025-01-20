using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Games.GetGame
{
    public class GetGameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
