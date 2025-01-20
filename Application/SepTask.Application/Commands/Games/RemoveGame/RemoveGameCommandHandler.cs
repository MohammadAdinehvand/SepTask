using MediatR;
using SepTask.Application.Commands.Games.UpdateGame;
using SepTask.Application.Exceptions;
using SepTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.RemoveGame
{
    public class RemoveGameCommandHandler : IRequestHandler<RemoveGameCommand, Unit>
    {
        private readonly IGameRepository _gameRepository;

        public RemoveGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<Unit> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
        {
            var game=await _gameRepository.GetByIdAsync(request.Id);
            if (game is null)
            {
                throw new GameNotFoundException(request.Id);
            }

            await _gameRepository.RemoveAsync(game);

            return Unit.Value;  
        }
    }
}
