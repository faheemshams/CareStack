using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class OpenRoomSeatAllocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        [ForeignKey("OpenRoom")]
        public int OpenRoomId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual OpenRoom OpenRoom { get; set; }
    }
}
