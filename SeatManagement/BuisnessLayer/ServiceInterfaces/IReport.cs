﻿using DataAccessLayer.Dto.ReportDto;

namespace BuisnessLayer.ServiceInterfaces
{
    public interface IReport<T> where T : class 
    {
        T[] GetView(FilterConditionsDto filters);
    }
}
