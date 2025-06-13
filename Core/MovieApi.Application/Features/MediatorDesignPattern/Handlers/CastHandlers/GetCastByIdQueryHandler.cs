using MediatR;
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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetCastByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _movieContext.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Name = values.Name,
                Surname = values.Surname,
                Title = values.Title,
                Overview = values.Overview,
                Biography = values.Biography,
                ImageUrl = values.ImageUrl
            };

        }
    }
}
