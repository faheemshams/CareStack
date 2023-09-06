using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int Floor { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public virtual City City { get; set; }
        public virtual Building Building { get; set; }
    }
}
