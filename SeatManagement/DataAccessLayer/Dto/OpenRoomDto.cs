using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class OpenRoomDto
    {
        public string OpenRoomName { get; set; }   
        public int SeatCount { get; set;}
        public int FacilityId { get; set; } 
    }
}
