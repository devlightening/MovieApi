using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCastQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<List<GetCastQueryResult>> Handle()
        {
            var values = await _movieContext.Casts.ToListAsync();
            return values.Select(x => new GetCastQueryResult
            {
                CastId = x.CastId,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                Biography = x.Biography,
                Overview = x.Overview,
                BirthDate = x.BirthDate,
                DeathDate = x.DeathDate

            }).ToList();
        }
    }
}

