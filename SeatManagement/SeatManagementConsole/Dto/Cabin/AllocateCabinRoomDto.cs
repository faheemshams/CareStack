using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto.Cabin
{
    public class AllocateCabinRoomDto
    {
        public string CabinName { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
