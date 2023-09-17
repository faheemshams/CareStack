using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class OpenRoomDto
    {
        public int? OpenRoomId { get; set; }
        public int SeatCount { get; set; }
        public int FacilityId { get; set; }
    }
}
