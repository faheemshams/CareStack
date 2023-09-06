using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class UpdateCabinRoomDto
    {
        public string CabinName { get; set; }  
        public int FacilityId { get; set; } 
        public int EmployeeId { get; set; } 
    }
}
