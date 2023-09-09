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
    public class ReportService<T> : IReport<ReportView>
    {
       
        public ReportService()
        {
           
        }

        public ReportView[] GetView(FilterConditionsDto filterCondition)
        {
           
        }
    }
}
