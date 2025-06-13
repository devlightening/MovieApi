
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetTagByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Tags.FindAsync(request.TagId);
            return new GetTagByIdQueryResult
            {
                TagId = values.TagId,
                Title = values.Title
            };        
        }
    }
}
