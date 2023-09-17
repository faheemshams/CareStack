using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ServicesImplementations
{
    internal class AssetService : IService<AssetDto, AssetMap>
    {
        private readonly IRepository<AssetMap> _assetRepository;

        public AssetService(IRepository<AssetMap> _assetRepository)
        {
            this._assetRepository = _assetRepository;
        }

        public AssetMap AddItem(AssetDto entity)
        {
            if (entity == null)
            return null;

            AssetMap assetMap = new AssetMap()
            {
                MeetingRoomId = entity.MeetingRoomId,
                LookupAssetId = entity.LookUpAssetId,
                Quantity = entity.Quantity,
            };

            _assetRepository.AddItem(assetMap);
            return assetMap;
        }

        public AssetMap DeleteItem(string name)
        {
            throw new NotImplementedException();
        }

        public AssetMap[] GetAllItems()
        {
            return _assetRepository.GetAllItems().ToArray();
        }

        public AssetMap GetItemById(int id)
        {
           return _assetRepository.GetItemById(id);
        }

        public AssetMap UpdateItem(AssetDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
