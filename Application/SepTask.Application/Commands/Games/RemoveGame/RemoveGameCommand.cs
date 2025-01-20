using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Commands.Games.RemoveGame
{
    public class RemoveGameCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
