
using Microsoft.EntityFrameworkCore;
using VehicleWatch.Data;
using VehicleWatch.Services;

namespace VehicleWatch
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

            builder.Services.AddScoped<IReport, ReportRepository>();
            builder.Services.AddScoped<IVehicle, VehicleRepository>();


            builder.Services.AddDbContext<VehicleDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            
            
            // hantera cors
            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("corspolicy");
            app.MapControllers();

            app.Run();
        }
    }
}
