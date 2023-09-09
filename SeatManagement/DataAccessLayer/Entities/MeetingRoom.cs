using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class MeetingRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingRoomId { get; set; }
        public string MeetingRoomNumber { get; set; }
        public int SeatCount { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
