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
    public class CabinRoomView : ICabinView
    {
        private readonly IRepository<CabinRoom> _cabinRoomRepository;
        public CabinRoomView(IRepository<CabinRoom> _cabinRoomRepository)
        {
            this._cabinRoomRepository = _cabinRoomRepository;
        }

        public IQueryable<ReportView> getView(int PageNumber, int PageSize)
        {
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
             }).Skip((PageNumber - 1) * PageSize).Take(PageSize);
            return CabinRoomReport;
        }
    }
}
