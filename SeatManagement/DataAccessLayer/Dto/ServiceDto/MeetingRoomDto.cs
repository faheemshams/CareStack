using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class MeetingRoomDto
    {
        public string? MeetingRoomNumber { get; set; }
        public int SeatCount { get; set; }
        public int FacilityId { get; set; }
    }
}
