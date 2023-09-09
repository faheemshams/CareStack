using DataAccessLayer.Dto.ReportDto;

namespace BuisnessLayer.Interfaces
{
    public interface IReport<T> where T : class 
    {
        T[] GetView(FilterConditionsDto filters);
    }
}
