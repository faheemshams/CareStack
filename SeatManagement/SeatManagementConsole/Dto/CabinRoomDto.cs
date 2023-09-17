using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class CabinRoomDto
    {
        public int? CabinRoomId { get; set; }
        public string CabinNumber { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
