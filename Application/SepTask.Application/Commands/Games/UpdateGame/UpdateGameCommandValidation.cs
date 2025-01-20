using FluentValidation;
using SepTask.Application.Commands.Games.CreateGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.UpdateGame
{
    public class UpdateGameCommandValidation : AbstractValidator<UpdateGameCommand>
    {

        public UpdateGameCommandValidation()
        {

            RuleFor(command => command.Id)
             .NotEmpty().WithMessage("Id is required.");

            RuleFor(command => command.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(command => command.GenreId)
                .NotEmpty().WithMessage("GenreId is required.");

            RuleFor(command => command.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");
        }

    }
}
