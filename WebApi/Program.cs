
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Middleware;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebApi
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

            builder.Services.AddSingleton<IProductService, ProductManager>();
            builder.Services.AddSingleton<IProductDal, EfProductDal>();



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:5002") // �zin verilen origin
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Global Exception Handler Middleware
            app.UseGlobalExceptionHandler();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // CORS policy tan�mla
          

            // CORS policy kullan
            app.UseCors("AllowSpecificOrigins");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
