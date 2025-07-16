using Microsoft.EntityFrameworkCore;
using ONLSHOP_ASP.NET;
using ONLSHOP_ASP.NET.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MovieDbCS")));
builder.Services.AddOpenApi();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<Context>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error has occured while migrating the database: {ex.Message}");
    }
}

app.MapMoviesEndpoints();
app.MapGenresEndpoints();
app.UseHttpsRedirection();
app.Run();
