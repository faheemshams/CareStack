using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class CityService<Tin, Tout> : IService<CityDto, City>
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

        public City GetItem(string cityAbbreviation)
        {
            var city = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == cityAbbreviation);

            if (city == null)
            return null;
            
            return _cityRepository.GetItemById(city.CityId);
        }

        public City AddItem(CityDto cityDto)
        {
            var city = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == cityDto.CityAbbreviation);

            if (city != null)
            return null;

            City newCity = new City()
            {
                CityAbbreviation = cityDto.CityAbbreviation,
                CityName = cityDto.CityName
            };

            _cityRepository.AddItem(newCity);
            return newCity;
        }

        public City DeleteItem(string cityAbbreviation)
        {
            var city = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == cityAbbreviation);

            if (city == null)
            return null;

            _cityRepository.DeleteItem(city.CityId);
            return city;
        } 

        public City UpdateItem(CityDto newCity)
        {
            var existingCity = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == newCity.CityAbbreviation);

            if (existingCity == null)
            return null;

            existingCity.CityName = newCity.CityName;
            existingCity.CityAbbreviation = newCity.CityAbbreviation;
            _cityRepository.UpdateItem(existingCity);
            return existingCity;
        }
    }
}


