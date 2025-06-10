using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entites;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly  MovieContext _movieContext;
        public CreateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(CreateMovieCommand command)
        {
            _movieContext.Movies.Add(new Movie
            {  
                    CoverImageUrl = command.CoverImageUrl,
                    CreatedYear = command.CreatedYear,
                    Description = command.Description,
                    Duration = command.Duration,
                    Rating = command.Rating,
                    ReleaseDate = command.ReleaseDate,
                    Status = command.Status,
                    Title = command.Title
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
