using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class FacilityService<Tin, Tout> : IService<FacilityDto, Facility>
    { 
        private readonly IRepository<Facility> _facilityRepository;
        public FacilityService(IRepository<Facility> _repository)
        {
            this._facilityRepository = _repository;
        }
        public Facility[] GetAllItems()
        {
            return _facilityRepository.GetAllItems().ToArray();
        }

        public Facility GetItem(string FacilityName)
        {
            var facility = _facilityRepository.GetAllItems().FirstOrDefault(x => x.FacilityName == FacilityName);

            if (facility == null)
            return null;

            return _facilityRepository.GetItemById(facility.FacilityId);
        }

        public Facility AddItem(FacilityDto facilityDto)
        {
            Facility facility = new Facility()
            {
                FacilityName = facilityDto.FacilityName,
                CityId = facilityDto.CityId,
                BuildingId = facilityDto.BuildingId,
                Floor = facilityDto.Floor
            };

            _facilityRepository.AddItem(facility);
            return facility;
        }

        public Facility DeleteItem(string FacilityName)
        {
            var facility = _facilityRepository.GetAllItems().FirstOrDefault(x => x.FacilityName == FacilityName);   

            if (facility == null)
            return null;

            _facilityRepository.DeleteItem(facility.FacilityId);
            return facility;
        }

        public Facility UpdateItem(FacilityDto newFacility)
        {
            var existingFacility = _facilityRepository.GetAllItems().FirstOrDefault(x => x.FacilityName == newFacility.FacilityName);

            if (existingFacility == null)
            return null;

            existingFacility.FacilityName = newFacility.FacilityName;
            existingFacility.BuildingId = newFacility.BuildingId;
            existingFacility.CityId = newFacility.CityId;   
            existingFacility.Floor = newFacility.Floor;              //checking needed
            _facilityRepository.UpdateItem(existingFacility);
            return existingFacility;
        }
    }
}


