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
    public class OpenRoomView : IOpenView
    {
        private readonly IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository;

        public OpenRoomView(IRepository<OpenRoomSeatAllocation> _openRoomSeatMapRepository)
        {
            this._openRoomSeatMapRepository = _openRoomSeatMapRepository;
        }

        public IQueryable<ReportView> getView(int PageNumber, int PageSize)
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
               }).Skip((PageNumber - 1) * PageSize).Take(PageSize);

            return openRoomReport;
        }
        }
    }
