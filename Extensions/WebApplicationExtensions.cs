using GameOfLife.Contracts;

namespace GameOfLife.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var gameOfLifeService = serviceScope.ServiceProvider.GetService<IGameOfLife>();

            // Get field as List<Cell>
            app.MapGet("/field", (HttpContext httpContext) => gameOfLifeService?.GetField())
            .WithName("GetField")
            .WithOpenApi();

            // Get field size as (int, int) where 1 argument is field width and second field height
            app.MapGet("/fieldsize", (HttpContext httpContext) => gameOfLifeService?.GetFieldSize())
            .WithName("GetFieldSize")
            .WithOpenApi();

            // Initialize a new field
            app.MapPost("/fieldinit", (int? width, int? height, HttpContext httpContext) => gameOfLifeService?.InitField(width, height))
            .WithName("PostInitField")
            .WithOpenApi();

            // Further Endpoint here
        }
    }
}
