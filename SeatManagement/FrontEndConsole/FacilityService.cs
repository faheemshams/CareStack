using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndConsole
{
    internal class FacilityService : IFacilityService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:5001"; // Replace with your API URL

        public FacilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }

        public async Task<FacilityModel> CreateAsync(FacilityModel facility)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/products", facility);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<FacilityModel>();
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception (e.g., log or throw custom exception)
                throw new Exception("Error while creating a new product via the API.", ex);
            }
        }

        public async Task<IEnumerable<FacilityModel>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/facilities");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<FacilityModel>>();
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception (e.g., log or throw custom exception)x
                throw new Exception("Error while fetching products from the API.", ex);
            }
        }

        public async Task<FacilityModel> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/products/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<FacilityModel>();
            }
            catch (HttpRequestException ex)
            {
                // Handle the exception (e.g., log or throw custom exception)
                throw new Exception($"Error while fetching product {id} from the API.", ex);
            }
        }
    }
}
