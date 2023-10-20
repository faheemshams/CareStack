using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class BuildingService<T> : IService<BuildingDto>
    {
        private readonly IRepository<Building> _buildingRepository;
        public BuildingService(IRepository<Building> _repository)
        {
            this._buildingRepository = _repository;
        }
        public BuildingDto[] GetAllItems()
        {
            Building[] buildings = _buildingRepository.GetAllItems().ToArray();
            BuildingDto[] buildingsDto = new BuildingDto[buildings.Length];

            for (int i = 0; i < buildings.Length; i++)
                buildingsDto[i] = ConvertBuildingsToBuildingsDto(buildings[i]);

            return buildingsDto;
        }

        public BuildingDto GetItemById(int BuildingId)
        {
            var building = _buildingRepository.GetItemById(BuildingId);

            if (building == null)
                throw new ExceptionWhileFetching("Building not found");
            else
                return ConvertBuildingsToBuildingsDto(building);
        }

        public void AddItem(BuildingDto building)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == building.BuildingAbbreviation);

            if (existingBuilding != null)
                throw new ExceptionWhileAdding("Building Abbrevation Already exist");

            Building newBuilding = new Building()
            {
                BuildingAbbreviation = building.BuildingAbbreviation,
                BuildingName = building.BuildingName,
                FloorCount = building.FloorCount,
            };
            _buildingRepository.AddItem(newBuilding);
        }

        public void DeleteItem(string buildingAbbreviation)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingAbbreviation);

            if (existingBuilding == null)
                throw new ExceptionWhileUpdating("Building not found");

            _buildingRepository.DeleteItem(existingBuilding.BuildingId);
        }

        public void UpdateItem(BuildingDto buildingDto)
        {
            var existingBuilding = _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingDto.BuildingAbbreviation);

            if (existingBuilding == null)
                throw new ExceptionWhileUpdating("Can't update building as building doesn't exist");

            if (buildingDto.newAbbreviation != null && buildingDto.newAbbreviation != buildingDto.BuildingAbbreviation && _buildingRepository.GetAllItems().FirstOrDefault(x => x.BuildingAbbreviation == buildingDto.newAbbreviation) != null)
                throw new ExceptionWhileUpdating("Duplicate abbreviation is not allowed");

            existingBuilding.BuildingName = buildingDto.BuildingName;
            existingBuilding.FloorCount = buildingDto.FloorCount;
            if(buildingDto.newAbbreviation != null)
            existingBuilding.BuildingAbbreviation = buildingDto.newAbbreviation;
            _buildingRepository.UpdateItem(existingBuilding);
        }

        private BuildingDto ConvertBuildingsToBuildingsDto(Building building)
        {
                return new BuildingDto()
                {
                    BuildingId = building.BuildingId,
                    BuildingAbbreviation = building.BuildingAbbreviation,
                    BuildingName = building.BuildingName,
                    FloorCount = building.FloorCount,
                };
        }
    }
}


