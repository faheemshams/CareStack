using DataAccessLayer.Dto.ReportDto;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ReportImplementations
{
    public class OpenRoomSeatReport<T> : IReport<OpenRoomView>
    {
        private readonly IRepository<OpenRoomSeatMap> _openRoomSeatMapRepository;

        public OpenRoomSeatReport(IRepository<OpenRoomSeatMap> _openRoomSeatMapRepository)
        {
            this._openRoomSeatMapRepository = _openRoomSeatMapRepository;
        }

        public OpenRoomView[] GetView()
        {
            var item = _openRoomSeatMapRepository.GetAllItems()
               .Include(x => x.OpenRoom)
               .Include(x => x.OpenRoom.Facilities)
               .Include(x => x.OpenRoom.Facilities.City)
               .Include(x => x.OpenRoom.Facilities.Building)
               .Include(x => x.Employee)
               .Select(x => new OpenRoomView
               {
                   SeatNumber = x.SeatNumber,
                   EmployeeId = x.EmployeeId,
                   EmployeeName = x.Employee.EmployeeName,
                   FacilityName = x.OpenRoom.Facilities.FacilityName,
                   Floor = x.OpenRoom.Facilities.Floor,
                   CityAbbreviation = x.OpenRoom.Facilities.City.CityAbbreviation,
                   BuildingAbbreviation = x.OpenRoom.Facilities.Building.BuildingAbbreviation
               }).ToArray();

            return item;
        }
    }
}
