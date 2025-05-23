
using CarRental.Identity.Data;
using CarRental.Identity.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarRental.Identity
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
            builder.Services.AddTransient<IIdentityService, IdentityService>();
            builder.Services.AddSingleton<IInMemoryDatabase, InMemoryDatabase>();
            builder.Services.AddTransient<IJwtService, JwtService>();
            builder.Services.AddAuthentication("Bearer")
                            .AddJwtBearer("Bearer", options =>
                            {
                                var config = builder.Configuration.GetSection("JwtSettings");
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidIssuer = config["Issuer"],
                                    ValidateAudience = true,
                                    ValidAudience = config["Audience"],
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(config["Key"])
                                    ),
                                    ValidateLifetime = true
                                };
                            });

            builder.Services.AddAuthorization();

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
