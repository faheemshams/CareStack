using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [ForeignKey("LookupRoomType")]
        public int RoomTypeId { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }  
        public virtual Department Department { get; set; }
        public virtual LookupRoomType LookupRoomType { get; set; }  
    }
}
