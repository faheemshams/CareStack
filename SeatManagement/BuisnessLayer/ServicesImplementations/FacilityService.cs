using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuisnessLayer.Services
{
    public class FacilityService<T> : IService<Facility>
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

        public Facility GetItemById(int id)
        {
            return _facilityRepository.GetItemById(id);
        }

        public Facility AddItem(Facility facility)
        {
            _facilityRepository.AddItem(facility);
            return facility;
        }

        public Facility DeleteItem(int id)
        {
            var facility = _facilityRepository.GetItemById(id);

            if (facility == null)
                return null;

            _facilityRepository.DeleteItem(id);
            return facility;
        }

        public Facility UpdateItem(Facility newFacility)
        {
            var existingFacility = _facilityRepository.GetItemById(newFacility.FacilityId);

            if (existingFacility == null)
            {
                return null;
            }

            existingFacility.FacilityName = newFacility.FacilityName;
            existingFacility.BuildingId = newFacility.BuildingId;
            existingFacility.CityId = newFacility.CityId;   
            existingFacility.Floor = newFacility.Floor; 
            _facilityRepository.UpdateItem(existingFacility);
            return newFacility;
        }
    }
}


