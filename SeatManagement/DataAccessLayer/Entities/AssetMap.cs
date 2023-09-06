using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class AssetMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetMapId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("MeetingRoom")]
        public int MeetingRoomId { get; set; }
        [ForeignKey("LookupAsset")]
        public int LookupAssetId { get; set; }
        public virtual MeetingRoom MeetingRoom { get; set; }
        public virtual LookupAsset LookupAsset { get; set; }


    }
}
