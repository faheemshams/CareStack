using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class EmployeeDto
    {
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DeptId { get; set; }
    }
}
