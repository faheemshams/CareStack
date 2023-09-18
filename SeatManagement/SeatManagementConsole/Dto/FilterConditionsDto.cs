using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class FilterConditionsDto
    {
        public string? SeatType { get; set; }
        public string? Locations { get; set; }
        public int Floor { get; set; }
        public string? FacilityName { get; set; }
        public string? SeatState { get; set; }
    }
}
