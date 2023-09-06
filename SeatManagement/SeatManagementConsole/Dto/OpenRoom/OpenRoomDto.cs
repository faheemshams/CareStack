using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto.OpenRoom
{
    public class OpenRoomDto
    {
        public int OpenRoomId { get; set; } 
        public string OpenRoomName { get; set; }
        public int SeatCount { get; set; }
        public int FacilityId { get; set; }
    }
}
