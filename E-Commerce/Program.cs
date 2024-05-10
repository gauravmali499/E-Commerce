
using E_Commerce.Data;
using E_Commerce.Data.SeedData;
using E_Commerce.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            //Add for json to database update
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var contex = services.GetRequiredService<StoreContext>();
                await contex.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(contex);
            } catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

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