using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class OpenRoomSeatAllocationDto
    {
        public int? AllocationId { get; set; }
        public string SeatNumber { get; set; }
        public int OpenRoomId { get; set; }
        public int EmployeeId { get; set; }
    }
}
