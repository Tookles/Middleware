using Microsoft.EntityFrameworkCore;
using MiddlewareApp.Database;
using MiddlewareApp.Middleware;
using MiddlewareApp.Model;
using MiddlewareApp.Service;

namespace MiddlewareApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 

            builder.Services.AddDbContext<ThisDbContext>( options =>
            {
                options.UseSqlServer(connectionString);
                options.UseValidationCheckConstraints();
            }

            );

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAdventurersRepository, AdventurersRepository>();
            builder.Services.AddScoped<IAdventurersService, AdventurersService>();


            builder.Services.AddTransient<LoggerMiddleware>(); 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<LoggerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(); 
            }

            app.UseHttpsRedirection();

            app.MapControllers(); 

            app.Run();
        }
    }
}
