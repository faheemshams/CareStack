using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto
{
    public class CreateEmployeeDto
    {
        public string EmployeeName { get; set; }
        public int DeptId { get; set; }
    }
}
