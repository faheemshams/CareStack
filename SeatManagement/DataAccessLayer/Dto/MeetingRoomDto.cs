using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class MeetingRoomDto
    {
        public string MeetingRoomName { get; set; }
        public int SeatCount { get; set; }  
        public int FacilityId { get; set; } 
    }
}
