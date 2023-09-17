using BuisnessLayer.Exceptions;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class AssetService<T> : IService<AssetDto>
    {
        private readonly IRepository<AssetMap> _assetRepository;
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;
        private readonly IRepository<LookupAsset> _lookupAssetRepository;

        public AssetService(IRepository<AssetMap> _assetRepository, IRepository<MeetingRoom> meetingRoomRepository, IRepository<LookupAsset> _lookupAsset)
        {
            this._assetRepository = _assetRepository;
            this._meetingRoomRepository = meetingRoomRepository;
            this._lookupAssetRepository = _lookupAsset;
        }

        public AssetDto[] GetAllItems()
        {
            AssetMap[] assetMappings = _assetRepository.GetAllItems().ToArray();
            AssetDto[] assetDtos = new AssetDto[assetMappings.Length];

            for(int i = 0; i < assetMappings.Length; i++)
            {
                assetDtos[i] = ConvertAssetToAssetDto(assetMappings[i]);
            }
            return assetDtos;   
        }
        public AssetDto GetItemById(int id)
        {
            var assetMap = _assetRepository.GetItemById(id);
            if (assetMap == null)
                throw new ExceptionWhileFetching("asset mapping not found");
            else
                return ConvertAssetToAssetDto(assetMap);
        }
        public void AddItem(AssetDto entity)
        {
            if (_meetingRoomRepository.GetItemById(entity.MeetingRoomId) == null)
                throw new ExceptionWhileAdding("Meeting room doesn't exist");
            if (_lookupAssetRepository.GetItemById(entity.LookUpAssetId) == null)
                throw new ExceptionWhileAdding("Asset not found");

            AssetMap assetMap = new AssetMap()
            {
                MeetingRoomId = entity.MeetingRoomId,
                LookupAssetId = entity.LookUpAssetId,
                Quantity = entity.Quantity,
            };

            _assetRepository.AddItem(assetMap);
        }

        public void DeleteItem(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(AssetDto entity)
        {
            throw new NotImplementedException();
        }

        private AssetDto ConvertAssetToAssetDto(AssetMap asset)
        {
           return new AssetDto()
            {
                MeetingRoomId = asset.MeetingRoomId,
                AssetMapId = asset.AssetMapId,
                LookUpAssetId = asset.LookupAssetId,
                Quantity = asset.Quantity,
            };
        }
    }
}
