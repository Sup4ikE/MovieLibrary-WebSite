using Microsoft.EntityFrameworkCore;

namespace ONLSHOP_ASP.NET.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (Context movieContext) => await movieContext.Genres.ToListAsync());
        
        return group;
    }
}