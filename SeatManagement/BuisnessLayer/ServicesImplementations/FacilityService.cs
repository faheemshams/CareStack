using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class FacilityService<T> : IService<FacilityDto>
    { 
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Building> _buildingRepository;
        private readonly IRepository<City> _cityRepository;
        public FacilityService(IRepository<Facility> _facilityRepository, IRepository<Building> _buildingRepository, IRepository<City> _cityRepository)
        {
            this._facilityRepository = _facilityRepository;
            this._buildingRepository = _buildingRepository; 
            this._cityRepository = _cityRepository; 
        }
        public FacilityDto[] GetAllItems()
        {
            Facility[] facilities =  _facilityRepository.GetAllItems().ToArray();
            FacilityDto[] facilityDtos = new FacilityDto[facilities.Length];

            for(int i = 0; i < facilities.Length; i++)
            {
                facilityDtos[i] = ConvertFacilityToFacilityDto(facilities[i]);  
            }
            return facilityDtos;
        }

        public FacilityDto GetItemById(int FacilityId)
        {
            var facility = _facilityRepository.GetItemById(FacilityId);
            if (facility == null)
                throw new ExceptionWhileFetching("Facility not found");
            else
                return ConvertFacilityToFacilityDto(facility);
        }

        public void AddItem(FacilityDto facilityDto)
        {
            if (_buildingRepository.GetItemById(facilityDto.BuildingId) == null)
                throw new ExceptionWhileAdding("Building not found");

            if (_buildingRepository.GetItemById(facilityDto.CityId) == null)
                throw new ExceptionWhileAdding("City not found");
            
            Facility facility = new Facility()
            {
                FacilityName = facilityDto.FacilityName,
                CityId = facilityDto.CityId,
                BuildingId = facilityDto.BuildingId,
                Floor = facilityDto.Floor
            };
            _facilityRepository.AddItem(facility);
        }

        public void UpdateItem(FacilityDto newFacility)
        {
            var existingFacility = _facilityRepository.GetAllItems().FirstOrDefault(x => x.FacilityId == newFacility.FacilityId);

            if (existingFacility == null)
                throw new ExceptionWhileUpdating("Facility not found");
            if (_buildingRepository.GetItemById(newFacility.BuildingId) == null)
                throw new ExceptionWhileUpdating("Building not found");
            if (_buildingRepository.GetItemById(newFacility.CityId) == null)
                throw new ExceptionWhileUpdating("City not found");

            existingFacility.FacilityName = newFacility.FacilityName;
            existingFacility.BuildingId = newFacility.BuildingId;
            existingFacility.CityId = newFacility.CityId;   
            existingFacility.Floor = newFacility.Floor;           

            _facilityRepository.UpdateItem(existingFacility);
        }

        private FacilityDto ConvertFacilityToFacilityDto(Facility facility)
        {
           return new FacilityDto()
            {
                FacilityId = facility.FacilityId,
                FacilityName = facility.FacilityName,
                BuildingId = facility.BuildingId,   
                CityId = facility.CityId,   
                Floor = facility.Floor, 
            };
        }
        public void DeleteItem(string FacilityName)
        {
            /*var facility = _facilityRepository.GetAllItems().FirstOrDefault(x => x.FacilityName == FacilityName);   

            if (facility == null)
            return null;

            _facilityRepository.DeleteItem(facility.FacilityId);
            return ConvertFacilityToFacilityDto(facility);*/
        }
    }
}


