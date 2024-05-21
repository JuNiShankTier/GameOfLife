using AutoMapper;
using GameOfLife.Contracts;
using GameOfLife.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLife.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var serviceScope = app.Services.CreateScope();
            var gameOfLifeService = serviceScope.ServiceProvider.GetService<IGameOfLife>();
            var mapper = serviceScope.ServiceProvider.GetService<IMapper>();

            app.MapGet("/field", (HttpContext httpContext) => mapper?.Map<FieldGetDto>(gameOfLifeService?.GetField()))
            .WithName("GetField")
            .WithOpenApi();

            app.MapPost("/fieldinit", ([FromQuery] int? width, [FromQuery] int? height, HttpContext httpContext) => gameOfLifeService?.InitField(width, height))
            .WithName("PostInitField")
            .WithOpenApi();

            app.MapPost("/nextfieldgeneration", (HttpContext httpContext) => gameOfLifeService?.NextGen())
            .WithName("PostNextFieldGeneration")
            .WithOpenApi();

            // Further Endpoint here
        }
    }
}
