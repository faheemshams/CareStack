using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class EmployeeDto
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int RoomTypeId { get; set; }
        public int DeptId { get; set; }
    }
}
