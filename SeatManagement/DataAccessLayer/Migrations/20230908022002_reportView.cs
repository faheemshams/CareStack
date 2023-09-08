using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class reportView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW OpenRoomView AS
              SELECT
                  OpenRoomSeatMaps.SeatNumber,
                  Employees.EmployeeId,
                  Employees.EmployeeName,
                  Facilities.FacilityName,
                  Facilities.Floor,
                  Cities.CityAbbreviation,
                  Buildings.BuildingAbbreviation
              FROM OpenRoomSeatMaps
              LEFT JOIN Employees ON OpenRoomSeatMaps.EmployeeId = Employees.EmployeeId
              LEFT JOIN OpenRooms ON OpenRoomSeatMaps.OpenRoomId = OpenRooms.OpenRoomId
              LEFT JOIN Facilities ON OpenRooms.FacilityId = Facilities.FacilityId
              LEFT JOIN Cities ON Facilities.CityId = Cities.CityId
              LEFT JOIN Buildings ON Facilities.BuildingId = Buildings.BuildingId
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
