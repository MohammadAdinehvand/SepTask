using MediatR;
using SepTask.Application.Queries.Games.GetAllGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Queries.Games.GetGame
{
    public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GetGameDto>
    {
        private readonly IDapperContext _dapperContext;

        public GetGameQueryHandler(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<GetGameDto> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Id", request.Id}
            };

            var game = await _dapperContext.GetAsync<GetGameDto>("sp_GetGameById_v1", parameters);

            return game;    

        }
    }
}
