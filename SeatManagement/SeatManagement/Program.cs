using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Implementations;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Dto.ReportDto;
using BuisnessLayer.ReportImplementations;

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
            builder.Services.AddScoped<IRepository<OpenRoomSeatAllocation>, SqlRepository<OpenRoomSeatAllocation>>();
            builder.Services.AddScoped<IRepository<AssetMap>, SqlRepository<AssetMap>>();
            builder.Services.AddScoped<IRepository<LookupAsset>, SqlRepository<LookupAsset>>();

            builder.Services.AddScoped<IService<AssetDto>, AssetService<AssetDto>>();
            builder.Services.AddScoped<IService<CityDto>, CityService<CityDto>>();
            builder.Services.AddScoped<IService<BuildingDto>, BuildingService<BuildingDto>>();
            builder.Services.AddScoped<IService<FacilityDto>, FacilityService<FacilityDto>>();
            builder.Services.AddScoped<IService<OpenRoomDto>, OpenRoomService<OpenRoomDto>>();
            builder.Services.AddScoped<IService<CabinRoomDto>, CabinService<CabinRoomDto>>();
            builder.Services.AddScoped<IService<EmployeeDto>, EmployeeService<EmployeeDto>>();
            builder.Services.AddScoped<IService<OpenRoomSeatAllocationDto>, OpenRoomSeatAllocationService<OpenRoomSeatAllocationDto>>();
            builder.Services.AddScoped<IService<CabinRoomDto>, CabinService<CabinRoomDto>>();
            builder.Services.AddScoped<IService<MeetingRoomDto>, MeetingRoomService<MeetingRoomDto>>();
           
            builder.Services.AddScoped<IView, View>();
            builder.Services.AddScoped<IReport, ReportService>();

          /*  builder.Services.AddScoped<IReport<ReportView>, ReportService<ReportView>>();*/


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