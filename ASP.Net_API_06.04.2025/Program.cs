
using ASP.Net_API_06._04._2025.Abstract;
using ASP.Net_API_06._04._2025.Core;
using ASP.Net_API_06._04._2025.DAL;
using ASP.Net_API_06._04._2025.DAL.Abstract;
using ASP.Net_API_06._04._2025.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP.Net_API_06._04._2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var conString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Products2025; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conString));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
