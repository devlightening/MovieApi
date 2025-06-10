using MovieApi.Application.Features.CQRSDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entites;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCastCommand command)
        {
            _movieContext.Casts.Add(new Cast
            {
                Name = command.Name,
                Surname = command.Surname,
                BirthDate = command.BirthDate,
                ImageUrl = command.ImageUrl,
                Biography = command.Biography,
                Overview = command.Overview,
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
