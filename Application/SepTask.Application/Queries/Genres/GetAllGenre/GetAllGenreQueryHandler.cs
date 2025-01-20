using MediatR;
using SepTask.Application.Queries.Games.GetAllGame;
using SepTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Genres.GetAllGenre
{
 
    public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, IEnumerable<GetAllGenreDto>>
    {
        private readonly IGenreRepository _genreRepository;

        public GetAllGenreQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GetAllGenreDto>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetAllAsync();

            return genres.Select(x=>new GetAllGenreDto() { Id=x.Id,Name=x.Name}).ToList();

        }
    }
}
