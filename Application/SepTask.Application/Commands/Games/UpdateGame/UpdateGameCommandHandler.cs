using MediatR;
using SepTask.Application.Commands.Games.CreateGame;
using SepTask.Application.Exceptions;
using SepTask.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.UpdateGame
{
    internal class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;

        public UpdateGameCommandHandler(IGameRepository gameRepository,IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }
        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var currentGamge = await _gameRepository.GetByIdAsync(request.Id);
            var gender= await _genreRepository.GetByIdAsync(request.GenreId);
            if (currentGamge is null)
            {
                throw new GameNotFoundException(request.Id);
            }
            if (gender is null)
            {
                throw new GenreNotFoundException(request.Id);
            }
            currentGamge.ChangeName(request.Name)
                        .ChangePrice(request.Price)
                        .ChangeReleaseDate(DateOnly.FromDateTime(request.ReleaseDate))
                        .ChangeGenre(gender);

            bool checkDuplicatedName=await _gameRepository.CheckDuplicatedNameAsync(currentGamge);
            if (checkDuplicatedName)
            {
                throw new GameDuplicateNameException(currentGamge.Name);
            }


            await _gameRepository.UpdateAsync(currentGamge);
            return Unit.Value;
        }
    }
}
