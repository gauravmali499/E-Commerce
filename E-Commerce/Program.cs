
using E_Commerce.Data;
using E_Commerce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddDbContext<StoreContext>(option => 
            { 
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")); 
            });
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