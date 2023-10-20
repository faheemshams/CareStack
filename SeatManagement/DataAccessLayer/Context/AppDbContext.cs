using DataAccessLayer.Dto.ReportDto;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AssetMap> AssetMappings { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CabinRoom> CabinRooms { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<LookupAsset> LookupAssets { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<OpenRoom> OpenRooms { get; set; }
        public DbSet<OpenRoomSeatAllocation> OpenRoomSeatMaps { get; set; }
        public DbSet<LookupRoomType> LookupRoomsType { get; set;}
        public DbSet<User> Users { get; set; }
    }
}
