using MediatR;
using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Games.GetAllGame
{
    public class GetAllGameQuery : IRequest<IEnumerable<GetAllGameDto>>
    {
    }
}
