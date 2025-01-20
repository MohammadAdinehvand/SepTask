using FluentValidation;
using SepTask.Application.Commands.Games.UpdateGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.RemoveGame
{

    public class RemoveGameCommandValidation : AbstractValidator<RemoveGameCommand>
    {

        public RemoveGameCommandValidation()
        {

            RuleFor(command => command.Id)
             .NotEmpty().WithMessage("Id is required.");
        }

    }

}
