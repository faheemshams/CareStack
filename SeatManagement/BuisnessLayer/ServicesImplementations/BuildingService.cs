
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuisnessLayer.Services
{
    public class BuildingService<T> : IService<Building>
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

        public Building GetItemById(int id)
        {
            return _buildingRepository.GetItemById(id);
        }

        public Building AddItem(Building building)
        {
            Building[] buildings = _buildingRepository.GetAllItems().ToArray();

            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingAbbreviation.Equals(building.BuildingAbbreviation))
                    return null;
            }

            _buildingRepository.AddItem(building);
            return building;
        }

        public Building DeleteItem(int id)
        {
            var city = _buildingRepository.GetItemById(id);

            if (city == null)
                return null;

            _buildingRepository.DeleteItem(id);
            return city;
        }

        public Building UpdateItem(Building newBuilding)
        {
            var existingBuilding = _buildingRepository.GetItemById(newBuilding.BuildingId);

            if (existingBuilding == null)
            {
                return null;
            }

            existingBuilding.BuildingName = newBuilding.BuildingName;
            existingBuilding.BuildingAbbreviation = newBuilding.BuildingAbbreviation;
            _buildingRepository.UpdateItem(existingBuilding);
            return newBuilding;
        }
    }
}


