using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementConsole.Dto.Employee
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DeptId { get; set; }
        public int RoomTypeId { get; set; }
    }
}
