using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {

        private readonly MovieContext _movieContext;
        public RemoveCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _movieContext.Movies.FindAsync(command.CategoryId);
          
             _movieContext.Movies.Remove(value);
            await _movieContext.SaveChangesAsync(); 
        }
    }
}
