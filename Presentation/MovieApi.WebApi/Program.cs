using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQuries;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using MovieApi.Persistance.Context;
using MovieApi.Persistance.Identity;
using System.Reflection;
using System.Security.Principal;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<MovieContext>();

        builder.Services.AddScoped<GetCategoryQueryHandler>();
        builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
        builder.Services.AddScoped<CreateCategoryCommandHandler>();
        builder.Services.AddScoped<RemoveCategoryCommandHandler>();
        builder.Services.AddScoped<UpdateCategoryCommandHandler>();

        builder.Services.AddScoped<GetMovieQueryHandler>();
        builder.Services.AddScoped<GetMovieByIdQueryHandler>();
        builder.Services.AddScoped<CreateMovieCommandHandler>();
        builder.Services.AddScoped<RemoveMovieCommandHandler>();
        builder.Services.AddScoped<UpdateMovieCommandHandler>();

        builder.Services.AddScoped<CreaterUserRegisterCommandHandler>();
        builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();


        //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));






        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}