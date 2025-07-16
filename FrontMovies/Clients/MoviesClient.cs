using FrontMovies.Models;

namespace FrontMovies.Clients;

public class MoviesClient(HttpClient httpClient)
{
    public async Task<Movie[]> GetMoviesAsync() =>await httpClient.GetFromJsonAsync<Movie[]>("movies") ?? [];
    
    //get the movie by id
    public async Task<Movie> GetMovieByIdAsync(int id) => await httpClient.GetFromJsonAsync<Movie>($"movies/{id}") ?? throw new Exception("Cound not find movie");

    //add a new movie
    public async Task AddMovieAsync(Movie movie) => await httpClient.PostAsJsonAsync("movies", movie);

    //update a movie
    public async Task UpdateMovieAsync(Movie updatedMovie) => await httpClient.PutAsJsonAsync($"movies/{updatedMovie.Id}", updatedMovie);
        
    // delete a movie
    public async Task DeleteMovieAsync(int id) => await httpClient.DeleteAsync($"movies/{id}");
}