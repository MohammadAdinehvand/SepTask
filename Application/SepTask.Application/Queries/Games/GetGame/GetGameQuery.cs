using MediatR;
using SepTask.Application.Queries.Games.GetAllGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Games.GetGame
{
    public class GetGameQuery : IRequest<GetGameDto>
    {
        public Guid Id { get; set; }
    }
}
