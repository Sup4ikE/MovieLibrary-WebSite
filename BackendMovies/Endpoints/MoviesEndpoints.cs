using Microsoft.EntityFrameworkCore;
using ONLSHOP_ASP.NET.Entities;

namespace ONLSHOP_ASP.NET.Endpoints;

public static class MoviesEndpoints
{
   public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies");

            //GET /movies
            group.MapGet("/", async (Context movieContext) => await movieContext.Movies.Include("Genre").ToListAsync());

            //Get /movies/{id}
            group.MapGet("/{id}", async (Context movieContext, int id) =>
            {

                Movie? movie = await movieContext.Movies.Include("Genre").FirstOrDefaultAsync(x => x.Id == id);

                return movie is null ? Results.NotFound() : Results.Ok(movie);

            });
            
            //POST /movies
            group.MapPost("/",async(Movie newMovie, Context movieContext) =>
            {
                newMovie.Genre = await movieContext.Genres.FirstOrDefaultAsync(x => x.Id == newMovie.GenreId);
                movieContext.Movies.Add(newMovie);
                await movieContext.SaveChangesAsync();
                return Results.Created($"/movies/{newMovie.Id}", newMovie);
            });
            
            //PUT /movies/1
            group.MapPut("/{id}", async (int id, Movie updatedMovie, Context movieContext) =>
            {
                Movie? movie = await movieContext.Movies.FindAsync(id);

                if (movie is null)
                {
                    return Results.NotFound();
                }


                //movieContext.Entry(movie).CurrentValues.SetValues(updatedMovie);

                if (updatedMovie.Name is not null) { movie.Name = updatedMovie.Name; }
                if (updatedMovie.GenreId != 0) { movie.GenreId = updatedMovie.GenreId; movie.Genre = movieContext.Genres.Find(updatedMovie.GenreId); }
                if (updatedMovie.Price != 0) { movie.Price = updatedMovie.Price; }
                if (updatedMovie.ReleaseDate != default) { movie.ReleaseDate = updatedMovie.ReleaseDate; }

                movieContext.Movies.Update(movie);
                await movieContext.SaveChangesAsync();
                return Results.NoContent();

            });
            
            //DELETE /movies/1
            group.MapDelete("/{id}", async (int id, Context movieContext) =>
            {
                // movies.RemoveAll(movie => movie.Id == id);
                Movie? movie = await movieContext.Movies.FindAsync(id);
                if (movie is null)
                {
                    return Results.NotFound();
                }

                movieContext.Movies.Remove(movie);
                await movieContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
