using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementConsole.Dto.Building
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingAbbreviation { get; set; }
        public int FloorCount { get; set; }
    }
}
