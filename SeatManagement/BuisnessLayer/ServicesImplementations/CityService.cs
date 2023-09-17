using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class CityService<T> : IService<CityDto>
    { 
        private readonly IRepository<City> _cityRepository;
        public CityService(IRepository<City> _repository)
        {
            this._cityRepository = _repository;
        }
        public CityDto[] GetAllItems()
        {
            City[] cities =  _cityRepository.GetAllItems().ToArray();
            CityDto[] cityDtos = new CityDto[cities.Length];

            for(int i = 0; i < cities.Length; i++)
            {
                cityDtos[i] = ConvertCityToCityDto(cities[i]);
            }
            return cityDtos;
        }

        public CityDto GetItemById(int CityId)
        {
            var city = _cityRepository.GetItemById(CityId);
            if (city == null)
                throw new ExceptionWhileFetching("City not found");
            else
                return ConvertCityToCityDto(city);
        }

        public void AddItem(CityDto cityDto)
        {
            var city = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == cityDto.CityAbbreviation);

            if (city != null)
                throw new ExceptionWhileAdding("City abbrevation already exist");

            City newCity = new City()
            {
                CityAbbreviation = cityDto.CityAbbreviation,
                CityName = cityDto.CityName
            };

            _cityRepository.AddItem(newCity);
        }

        public void DeleteItem(string cityAbbreviation)
        {
            var city = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == cityAbbreviation);

            if (city == null)
                throw new ExceptionWhileFetching("City doesn't exist");

            _cityRepository.DeleteItem(city.CityId);
        } 

        public void UpdateItem(CityDto newCity)
        {
            var existingCity = _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == newCity.CityAbbreviation);

            if (existingCity == null)
                throw new ExceptionWhileFetching("The city doesn't exist");

            if (newCity.newAbbreviation != null && newCity.newAbbreviation != newCity.CityAbbreviation && _cityRepository.GetAllItems().FirstOrDefault(x => x.CityAbbreviation == newCity.newAbbreviation) != null)
                throw new ExceptionWhileUpdating("Duplicate abbrevation not allowed");
                
            existingCity.CityAbbreviation = newCity.newAbbreviation;
            existingCity.CityName = newCity.CityName;
            _cityRepository.UpdateItem(existingCity);
        }
        private CityDto ConvertCityToCityDto(City city)
        {
            return new CityDto()
            {
                CityId = city.CityId,
                CityName = city.CityName,
                CityAbbreviation = city.CityAbbreviation,
            };
        }
    }
}


