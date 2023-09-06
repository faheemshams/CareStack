using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Implementations;
using BuisnessLayer.ServiceInterfaces;
using BuisnessLayer.Services;

namespace PresentationLayer
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

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            builder.Services.AddScoped<IRepository<Building>, SqlRepository<Building>>();
            builder.Services.AddScoped<IRepository<City>, SqlRepository<City>>();
            builder.Services.AddScoped<IRepository<Department>, SqlRepository<Department>>();
            builder.Services.AddScoped<IRepository<AssetMap>, SqlRepository<AssetMap>>();
            builder.Services.AddScoped<IRepository<CabinRoom>, SqlRepository<CabinRoom>>();
            builder.Services.AddScoped<IRepository<Employee>, SqlRepository<Employee>>();
            builder.Services.AddScoped<IRepository<Facility>, SqlRepository<Facility>>();
            builder.Services.AddScoped<IRepository<LookupAsset>, SqlRepository<LookupAsset>>();
            builder.Services.AddScoped<IRepository<MeetingRoom>, SqlRepository<MeetingRoom>>();
            builder.Services.AddScoped<IRepository<OpenRoom>, SqlRepository<OpenRoom>>();
            builder.Services.AddScoped<IRepository<OpenRoomSeatMap>, SqlRepository<OpenRoomSeatMap>>();

            builder.Services.AddScoped<IService<City>, CityService<City>>();
            builder.Services.AddScoped<IService<Building>, BuildingService<Building>>();
            builder.Services.AddScoped<IService<Facility>, FacilityService<Facility>>();
            builder.Services.AddScoped<IService<OpenRoom>, OpenRoomService<OpenRoom>>();
            builder.Services.AddScoped<IService<CabinRoom>, CabinRoomService<CabinRoom>>();
            builder.Services.AddScoped<IService<Employee>, EmployeeService<Employee>>();
            builder.Services.AddScoped<IService<OpenRoomSeatMap>, EmployeeAllocationService<OpenRoomSeatMap>>();
            builder.Services.AddScoped<IService<CabinRoom>, CabinService<CabinRoom>>();
            builder.Services.AddScoped<IService<MeetingRoom>, MeetingRoomService<MeetingRoom>>();


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

            //Seed database
            AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}