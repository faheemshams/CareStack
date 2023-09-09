using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class CabinRoomDto
    {
        public string? CabinNumber { get; set; }
        public int? FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
