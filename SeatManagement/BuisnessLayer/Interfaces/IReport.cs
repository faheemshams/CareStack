using DataAccessLayer.Dto.ReportDto;

namespace BuisnessLayer.Interfaces
{
    public interface IReport
    {
        ReportView[] GetView(FilterConditionsDto filters, int PageNumber, int PageSize);
    }
}
