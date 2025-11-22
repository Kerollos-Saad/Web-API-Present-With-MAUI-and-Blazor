
using Demo.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<DemoDbContext>(x =>
            {
	            var connectionString = builder.Configuration.GetConnectionString("DbConnection");
	            x.UseSqlServer(connectionString);
            });

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowBlazor",
					policy => policy
						//.WithOrigins(
						//	"http://localhost:5067", 
						//	"https://localhost:5067",
						//	"http://0.0.0.0:5067",
						//	"http://0.0.0.0:5015")
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});

			//builder.WebHost.UseUrls("http://0.0.0.0:5015", "http://192.168.1.111:5015", "http://localhost:5015");

			var app = builder.Build();

			// Add before app.MapControllers()
			app.UseCors("AllowBlazor");

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
	                options.SwaggerEndpoint("/openapi/v1.json", "Demo API v1");
	                options.RoutePrefix = string.Empty;
                });
            }

			app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
