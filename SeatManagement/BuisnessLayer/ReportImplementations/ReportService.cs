using DataAccessLayer.Dto.ReportDto;
using BuisnessLayer.Interfaces;
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
    public class ReportService: IReport
    {
        private readonly IView view;
        public ReportService(IView view)
        {
            this.view = view;   
        }

        public ReportView[] GetView(FilterConditionsDto filterCondition)
        {
            var report = view.GetView();

            if (filterCondition.SeatType == "OpenRoom")
                report = report.Where(x => x.SeatNumber.StartsWith('S')).ToArray();
            else if(filterCondition.SeatType == "CabinRoom")
                report = report.Where(x => x.SeatNumber.StartsWith('C')).ToArray();

            if(filterCondition.Locations != null)
                report = report.Where(x => x.CityAbbreviation == filterCondition.Locations).ToArray();

            if(filterCondition.Floor != null)
                report = report.Where(x => x.Floor == filterCondition.Floor).ToArray();

            if(filterCondition.SeatState == "free")
                report = report.Where(x => x.EmployeeId == null).ToArray();

            if (filterCondition.SeatState == "allocated")
                report = report.Where(x => x.EmployeeId == null).ToArray();

            if (filterCondition.FacilityName != null)
                report = report.Where(x => x.FacilityName == filterCondition.FacilityName).ToArray();   
            return report;
        }
    }
}
