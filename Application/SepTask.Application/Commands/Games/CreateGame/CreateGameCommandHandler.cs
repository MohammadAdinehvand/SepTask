using MediatR;
using SepTask.Application.Exceptions;
using SepTask.Domain.Models;
using SepTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Unit>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        public CreateGameCommandHandler(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }
        public async Task<Unit> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.GenreId);

            if (genre is null)
            {
                throw new GenreNotFoundException(request.GenreId);
            }
            var existsGame = await _gameRepository.GetByNameAsync(request.Name.Trim());
            if (existsGame is not null)
            {
                throw new GameAlreadyExistsException(request.Name);
            }
            var game = new Game(request.Name.Trim(), genre, request.Price,DateOnly.FromDateTime(request.ReleaseDate));
            await _gameRepository.AddAsync(game);
            return Unit.Value;
        }
    }
}
