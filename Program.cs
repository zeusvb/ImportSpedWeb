
using ImportSpedWeb.Custom;
using ImportSpedWeb.Data;
using ImportSpedWeb.Interfaces;
using ImportSpedWeb.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.Text;

namespace ImportSpedWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //var connectionString = builder.Configuration.GetConnectionString("ImportConnection");
            //builder.Services.AddDbContext<ImportSpedContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<MiDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
            //});
            var connectionString = builder.Configuration.GetConnectionString("ImportConnection");
            builder.Services.AddDbContext<ImportSpedContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddSingleton<Utilidades>();

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
                };

            });
            builder.Services.AddHostedService<MyBackgroundTask>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("NewPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
