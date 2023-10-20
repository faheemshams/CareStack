using DataAccessLayer.Dto.ReportDto;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Implementations;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.ReportImplementations
{
    public class ReportService: IReport
    {
        private readonly IOpenView openView;
        private readonly ICabinView cabinView;
        public ReportService(IOpenView openView, ICabinView cabinView)
        {
            this.openView = openView;
            this.cabinView = cabinView; 
        }

        public ReportView[] GetView(FilterConditionsDto filterCondition, int PageNumber, int PageSize)
        {
            IQueryable<ReportView> report;

            if (filterCondition.SeatType == "OpenRoom")
                report = openView.getView(PageNumber, PageSize);
            else if (filterCondition.SeatType == "CabinRoom")
                report = cabinView.getView(PageNumber, PageSize);    
            else
                throw new ExceptionWhileFetching("Enter OpenRoom or CabinRoom");

            if (filterCondition.Locations != null)
                report = report.Where(x => x.CityAbbreviation == filterCondition.Locations);

            if (filterCondition.Floor != 0)
                report = report.Where(x => x.Floor == filterCondition.Floor);

            if (filterCondition.SeatState == "Free")
                report = report.Where(x => x.EmployeeId == null);

            if (filterCondition.SeatState == "Allocated")
                report = report.Where(x => x.EmployeeId != null);

            if (filterCondition.FacilityName != null)
                report = report.Where(x => x.FacilityName == filterCondition.FacilityName);  
            return report.ToArray();
        }
    }
}
