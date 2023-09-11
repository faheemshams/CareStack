using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class BuildingService<Tin, Tout> : IService<BuildingDto, Building>
    {
        private readonly IRepository<Building> _buildingRepository;
        public BuildingService(IRepository<Building> _repository)
        {
            this._buildingRepository = _repository;
        }
        public Building[] GetAllItems()
        {
            return _buildingRepository.GetAllItems().ToArray();
        }

        public Building GetItem(string buildingAbbreviation)
        {
            var building = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingAbbreviation);

            if (building != null)
            return null;

            return _buildingRepository.GetItemById(building.BuildingId);
        }

        public Building AddItem(BuildingDto building)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == building.BuildingAbbreviation);

            if (existingBuilding != null)
            return null;

            Building newBuilding = new Building()
            {
                BuildingAbbreviation = building.BuildingAbbreviation,
                BuildingName = building.BuildingName,
            };

            _buildingRepository.AddItem(newBuilding);
            return newBuilding;
        }

        public Building DeleteItem(string buildingAbbreviation)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingAbbreviation);

            if (existingBuilding == null)
            return null;

            _buildingRepository.DeleteItem(existingBuilding.BuildingId);
            return existingBuilding;
        }

        public Building UpdateItem(BuildingDto buildingDto)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingDto.BuildingAbbreviation);

            if (existingBuilding == null)
            return null;

            existingBuilding.BuildingName = buildingDto.BuildingName;
            existingBuilding.BuildingAbbreviation = buildingDto.BuildingAbbreviation;
            
            _buildingRepository.UpdateItem(existingBuilding);
            return existingBuilding;
        }
    }
}


