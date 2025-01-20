using MediatR;
using Microsoft.AspNetCore.Mvc;
using SepTask.Api.Response;
using SepTask.Application.Commands.Games.CreateGame;
using SepTask.Application.Commands.Games.RemoveGame;
using SepTask.Application.Commands.Games.UpdateGame;
using SepTask.Application.Queries.Games.GetAllGame;
using SepTask.Application.Queries.Games.GetGame;
using System.Threading;

namespace SepTask.Api.Controllers
{
    public class GameController(IMediator mediator) : BaseController
    {
        private readonly IMediator mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGameCommand command)
        {
            await mediator.Send(command);
            return Ok(ApiResponse.Ok());
        }
        [HttpGet("games")]
        public async Task<ActionResult<IEnumerable<GetAllGameDto>>> Get([FromQuery] GetAllGameQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(ApiResponse.Ok(result));
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetGameDto>> Get([FromRoute] GetGameQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(ApiResponse.Ok(result));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateGameCommand command)
        {
            await mediator.Send(command);
            return Ok(ApiResponse.Ok());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveGameCommand command)
        {
            await mediator.Send(command);
            return Ok(ApiResponse.Ok());
        }
    }
}
