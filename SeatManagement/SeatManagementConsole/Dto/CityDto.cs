﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class CityDto
    {
        public int? CityId { get; set; }
        public string CityAbbreviation { get; set; }
        public string CityName { get; set; }
        public string? newAbbreviation { get; set; }

    }
}
