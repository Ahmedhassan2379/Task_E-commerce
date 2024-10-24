using E_commerce.Api.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Infrastracture.Repository;

namespace E_commerce.Api.Extention
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            return services;

        }
    }
}
