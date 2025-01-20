using MediatR;
using SepTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Games.GetAllGame
{
    public class GetAllGameQueryHandler : IRequestHandler<GetAllGameQuery, IEnumerable<GetAllGameDto>>
    {
        private readonly IDapperContext _dapperContext;

        public GetAllGameQueryHandler(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<GetAllGameDto>> Handle(GetAllGameQuery request, CancellationToken cancellationToken)
        {
            var games = await _dapperContext.GetAllAsync<GetAllGameDto>("[dbo].[sp_GetAllGame_v1]");

            return games;

        }
    }
}
