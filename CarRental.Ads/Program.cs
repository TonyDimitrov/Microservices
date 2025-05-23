
using CarRental.Ads.Messages;
using CarRental.Ads.Services;
using MassTransit;

namespace CarRental.Ads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IInMemoryDatabase, InMemoryDatabase>();
            builder.Services.AddTransient<ICarAdService, CarAdService>();
            builder.Services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((bus, cfg) =>
                {
                    cfg.Host("localhost");

                    cfg.ConfigureEndpoints(bus);
                });
            });

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
