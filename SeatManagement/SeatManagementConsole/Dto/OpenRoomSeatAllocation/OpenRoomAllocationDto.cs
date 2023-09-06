using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto.OpenRoomSeatAllocation
{
    class OpenRoomAllocationDto
    {
        public int SeatId { get; set; } 
        public int SeatNumber { get; set; }
        public int OpenRoomId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
