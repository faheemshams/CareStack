﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto.ReportDto
{
    public class OpenRoomView
    {
        public int SeatNumber { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string FacilityName { get; set; }
        public int Floor { get; set; }
        public string CityAbbreviation { get; set; }
        public string BuildingAbbreviation { get; set; }
    }
}
