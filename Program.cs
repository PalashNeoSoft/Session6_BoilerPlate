
using HealthChecks.UI.Client;
using Microsoft.EntityFrameworkCore;
using Session6_BoilerPlate.AppDbContext;
using Session6_BoilerPlate.HealthChecks;
using Session6_BoilerPlate.Repository;

namespace Session6_BoilerPlate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string con = builder.Configuration.GetConnectionString("localConnectionString");
            builder.Services.AddDbContext<ProductDb>(p => p.UseSqlServer(con));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Adding HealthChecks
            builder.Services
                    .AddHealthChecks()
                    .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapHealthChecks("/health", new()
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });  //EndPoint 

            app.MapControllers();

            app.Run();
        }
    }
}