using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dto.ServiceDto
{
    public class AssetDto
    {
        public int? AssetMapId { get; set; }    
        public int MeetingRoomId { get; set; }  
        public int LookUpAssetId { get; set; }  
        public int Quantity { get; set; }   
    }
}
