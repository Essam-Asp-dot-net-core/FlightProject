using Flight.Core.Identity;
using Flight.Core.IRepository;
using Flight.Repository.Identity;
using Flight.Repository.MyFlightDbContext;
using Flight.Repository.Repository;
using FlightProject.Errors;
using FlightProject.Extention;
using FlightProject.Extentions;
using FlightProject.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProjectRoateAcademy.MiddelWare;

namespace FightProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Dependance InJection
            builder.Services.AddApplicationServices();

			//DbContext
			builder.Services.AddDbContext<FlightDbContext>(Option=>
            {
                Option.UseSqlServer(builder.Configuration.GetConnectionString("FlightContext"));
            });


            builder.Services.AddDbContext<AppIdentityDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityContext"));   
            });

            // I Make This Services To Contain All Services About Identity 
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddCors(Options=>
            {
                Options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader()
                           .AllowAnyOrigin()
                           .AllowAnyMethod();
                });
            });


			var app = builder.Build();

            app.UseCors("AllowAll");

           using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var LoggerFactory = Services.GetService<ILoggerFactory>();
            try
            {
                var context = Services.GetRequiredService<FlightDbContext>();
                await context.Database.MigrateAsync();
                var IdentityContext = Services.GetRequiredService<AppIdentityDbContext>();
                await IdentityContext.Database.MigrateAsync();
                var usermanger = Services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextDataSeed.SeedUserAsync(usermanger);
            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex , ex.Message);
                
            }



            //Error MiddleWare
			app.UseMiddleware<ExceptionMiddleWare>();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
