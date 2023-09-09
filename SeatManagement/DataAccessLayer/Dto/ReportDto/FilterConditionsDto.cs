using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ReportDto
{
    public class FilterConditionsDto
    {
        public String[] SeatType { get; set; }
        public String[] Locations { get; set; }
        public int[] Floor { get; set; }  
        public string[] FacilityName {get; set; }
        public string[] SeatState { get; set; } 
    }
}
