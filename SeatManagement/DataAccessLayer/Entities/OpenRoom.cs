using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class OpenRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OpenRoomId { get; set; }
        public int SeatCount { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility Facilities { get; set; }
    }
}
