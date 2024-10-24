
using E_commerce.Api.Extention;
using E_commerce.Api.Helper;
using E_commerce.Application.Interfaces;
using E_commerce.Infrastracture.Data;
using E_commerce.Infrastracture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRepositoryConfiguration(builder.Configuration);

            //Passing ConnectionString Into ApplicationDbContext
            builder.Services.AddDbContext<ApplicationDbContext>(option => option
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            

            var app = builder.Build();

            #region UpdateDatabase Dynamic
            using var scope = app.Services.CreateScope();     //create scope that container all config services
            var services = scope.ServiceProvider;       //filter for services from this scope 
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = services.GetRequiredService<ApplicationDbContext>();    //Ask CLR to create object from DBContext
                await dbContext.Database.MigrateAsync();                        //update Database
                await DataSeedContext.SeedAsync(dbContext);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
