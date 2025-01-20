using MediatR;
using Microsoft.AspNetCore.Mvc;
using SepTask.Api.Response;
using SepTask.Application.Commands.Games.CreateGame;
using SepTask.Application.Queries.Games.GetAllGame;
using SepTask.Application.Queries.Genres.GetAllGenre;
using System.Threading;

namespace SepTask.Api.Controllers
{
    public class GenreController(IMediator mediator) : BaseController
    {
        private readonly IMediator mediator = mediator;

        [HttpGet("genres")]
        public async Task<ActionResult<IEnumerable<GetAllGenreDto>>> Get([FromQuery] GetAllGenreQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(ApiResponse.Ok(result));
        }

    }
}
