using DataAccessLayer.Dto.ReportDto;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class View : IView
    {
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;
        private readonly IRepository<CabinRoom> _cabinRoomRepository;

        public View(IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository, IRepository<CabinRoom> _cabinRoomRepository)
        {
            this._openRoomSeatMapRepository = _openRoomSeatMapRepository;
            this._cabinRoomRepository = _cabinRoomRepository;
        }

        public ReportView[] GetView()
        {
            var openRoomReport = _openRoomSeatMapRepository.GetAllItems()
               .Include(x => x.OpenRoom)
               .Include(x => x.OpenRoom.Facilities)
               .Include(x => x.OpenRoom.Facilities.City)
               .Include(x => x.OpenRoom.Facilities.Building)
               .Include(x => x.Employee)
               .Select(x => new ReportView
               {
                   SeatNumber = x.SeatNumber,
                   EmployeeId = x.EmployeeId,
                   EmployeeName = x.Employee.EmployeeName,
                   FacilityName = x.OpenRoom.Facilities.FacilityName,
                   Floor = x.OpenRoom.Facilities.Floor,
                   CityAbbreviation = x.OpenRoom.Facilities.City.CityAbbreviation,
                   BuildingAbbreviation = x.OpenRoom.Facilities.Building.BuildingAbbreviation
               }).ToArray();

            var CabinRoomReport = _cabinRoomRepository.GetAllItems()
                .Include(x => x.Employee)
                .Include(x => x.Facility)
                .Include(x => x.Facility.Building)
                .Include(x => x.Facility.City)
                .Select(x => new ReportView
                {
                    SeatNumber = x.CabinNumber,
                    EmployeeId = x.EmployeeId,
                    EmployeeName = x.Employee.EmployeeName,
                    FacilityName = x.Facility.FacilityName,
                    Floor = x.Facility.Floor,
                    CityAbbreviation = x.Facility.City.CityAbbreviation,
                    BuildingAbbreviation = x.Facility.Building.BuildingAbbreviation
                }).ToArray();

            return openRoomReport.Concat(CabinRoomReport).ToArray();
        }
    }
}
