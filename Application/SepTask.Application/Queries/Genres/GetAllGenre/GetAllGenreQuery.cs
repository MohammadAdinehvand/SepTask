using MediatR;
using SepTask.Application.Queries.Games.GetAllGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Genres.GetAllGenre
{

    public class GetAllGenreQuery : IRequest<IEnumerable<GetAllGenreDto>>
    {
    }
}
