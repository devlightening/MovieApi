
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entites;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
             _movieContext.Casts.Add(new Cast
            {
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                ImageUrl = request.ImageUrl,
                Biography = request.Biography,
                Overview = request.Overview

            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
