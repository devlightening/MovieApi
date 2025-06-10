using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryByIdHandler
    {
        private readonly MovieContext _movieContext;
        public GetCastQueryByIdHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        
        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery query)
        {
            var value = await _movieContext.Casts.FindAsync(query.CastId);
            return new GetCastByIdQueryResult
            {
                CastId=value.CastId,
                Name = value.Name,
                Surname = value.Surname,
                ImageUrl = value.ImageUrl,
                Biography = value.Biography,
                Overview = value.Overview,
                BirthDate = value.BirthDate,
                DeathDate = value.DeathDate
            };
        }
    }
}
