using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class CabinRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CabinId { get; set; }
        public string CabinNumber { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
