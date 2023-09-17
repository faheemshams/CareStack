using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Dto
{
    public class BuildingDto
    {
        public int? BuildingId { get; set; }
        public string BuildingAbbreviation { get; set; }
        public string BuildingName { get; set; }
        public int FloorCount { get; set; }
        public string? newAbbreviation { get; set; }
    }
}
