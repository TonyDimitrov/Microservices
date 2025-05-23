
using CarRental.Dealers.Data;
using CarRental.Dealers.Messages;
using CarRental.Dealers.Services;
using CarRental.Infrastructure.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarRental.Dealers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IInMemoryData, InMemoryData>();
            builder.Services.AddTransient<IDealerService, DealerService>();
            builder.Services.AddMassTransit(mt =>
            {
                mt.AddConsumer<CarAdCreatedConsumer>();
                mt.UsingRabbitMq((bus, cfg) =>
                {
                    cfg.Host("localhost");

                    cfg.ConfigureEndpoints(bus);
                    cfg.ReceiveEndpoint("car-advert", endpoint =>
                    {
                        endpoint.ConfigureConsumer<CarAdCreatedConsumer>(bus);
                    });
                });
            });

            var config = builder.Configuration.GetSection("JwtSettings");
            builder.Services.AddJwtAuthentication(config["Key"], config["Issuer"], config["Audience"]);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
