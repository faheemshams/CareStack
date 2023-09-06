using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class UpdateEmployeeDto
    {
        public string EmployeeName { get; set; }    
        public int RoomTypeId { get; set; }   
        public int DeptId { get; set; } 

    }
}
