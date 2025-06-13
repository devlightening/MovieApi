using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _movieContext;

        public GetCastQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.ToListAsync();
            return values.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Name = x.Name,
                Surname = x.Surname,
                Title = x.Title,
                Overview = x.Overview,
                Biography = x.Biography,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
