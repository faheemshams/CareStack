using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto.Facility
{
    public class CreateFacilityDto
    {
        public string FacilityName { get; set; }
        public int Floor { get; set; }
        public int CityId { get; set; }
        public int BuildingId { get; set; }
    }
}
