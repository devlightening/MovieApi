using MediatR;
using MovieApi.Persistance.Context;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.FindAsync(request.CastId);
            _movieContext.Casts.Remove(values);
            await _movieContext.SaveChangesAsync();
        }
    }
}
