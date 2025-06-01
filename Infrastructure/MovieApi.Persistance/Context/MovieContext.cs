using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApi.Domain.Entites;

namespace MovieApi.Persistance.Context
{
    public class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4UQ0AMN\\SQLEXPRESS01;initial Catalog=ApiMovieDb;integrated Security=true; TrustServerCertificate=true");
        }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
