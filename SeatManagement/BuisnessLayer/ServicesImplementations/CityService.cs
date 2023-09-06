
using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BuisnessLayer.Services
{
    public class CityService<T> : IService<City>
    { 
        private readonly IRepository<City> _cityRepository;
        public CityService(IRepository<City> _repository)
        {
            this._cityRepository = _repository;
        }
        public City[] GetAllItems()
        {
            return _cityRepository.GetAllItems().ToArray();
        }

        public City GetItemById(int id)
        {
            return _cityRepository.GetItemById(id);
        }

        public City AddItem(City city)
        {
            City[] cities = _cityRepository.GetAllItems().ToArray();
            
            for(int i=0; i<cities.Length; i++) 
            {
                if (cities[i].CityAbbreviation.Equals(city.CityAbbreviation))
                return null;
            }

            _cityRepository.AddItem(city);
            return city;
        }

        public City DeleteItem(int id)
        {
            var city = _cityRepository.GetItemById(id);

            if (city == null)
            return null;

            _cityRepository.DeleteItem(id);
            return city;
        } 

        public City UpdateItem(City newCity)
        {
            var existingCity = _cityRepository.GetItemById(newCity.CityId);

             if (existingCity == null)
             {
                return null;
             }

             existingCity.CityName = newCity.CityName;
             existingCity.CityAbbreviation = newCity.CityAbbreviation;
             _cityRepository.UpdateItem(existingCity);
             return newCity;
        }
    }
}


