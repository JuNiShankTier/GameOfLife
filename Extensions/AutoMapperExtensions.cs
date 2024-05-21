using AutoMapper;
using GameOfLife.DTOs;
using GameOfLife.Models;

namespace GameOfLife.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Field, FieldGetDto>().ReverseMap();
            });
            var mapper = new Mapper(configuration);
            services.AddSingleton<IMapper>(mapper);
        }
    }
}
