using ONLSHOP_ASP.NET.Entities;

namespace ONLSHOP_ASP.NET;
using Microsoft.EntityFrameworkCore;

    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Sci-Fi" },
                new Genre { Id = 3, Name = "Fantasy" },
                new Genre { Id = 4, Name = "Horror" },
                new Genre { Id = 5, Name = "Romance" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Inception", GenreId = 1, Price = 120000, ReleaseDate = new DateOnly(2003, 1, 1) },
                new Movie { Id = 2, Name = "The Dark Knight", GenreId = 1, Price = 14000, ReleaseDate = new DateOnly(2005, 1, 1) },
                new Movie { Id = 3, Name = "Interstellar", GenreId = 2, Price = 10000, ReleaseDate = new DateOnly(2007, 1, 1) },
                new Movie { Id = 4, Name = "The Matrix", GenreId = 2, Price = 90000, ReleaseDate = new DateOnly(1999, 1, 1) },
                new Movie { Id = 5, Name = "The Lord of the Rings: The Fellowship of the Ring", GenreId = 3, Price = 11000, ReleaseDate = new DateOnly(2001, 1, 1) },
                new Movie { Id = 6, Name = "The Lord of the Rings: The Two Towers", GenreId = 3, Price = 110000, ReleaseDate = new DateOnly(2002, 1, 1) }
            );
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=SHOP;username=postgres;password=1846Awlq;");
        }
    }

