using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class CreateCabinRoomDto
    {
        public string CabinName { get; set; }
        public int FacilityId { get; set; }
    }
}
