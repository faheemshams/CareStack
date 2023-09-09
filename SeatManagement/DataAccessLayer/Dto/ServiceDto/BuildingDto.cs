using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class BuildingDto
    {
        public string BuildingName { get; set; }
        public string BuildingAbbreviation { get; set; }
        public int FloorCount { get; set; }
    }
}
