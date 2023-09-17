using Newtonsoft.Json;
using SeatManagementConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Implementation
{
    public class SeatManagementAPICall<T> : IAllocationManagerApi<T> where T : class
    {
        private readonly HttpClient client;
        public string apiEndpoint;
        public SeatManagementAPICall(string apiEndpoint)
        {
            this.apiEndpoint = apiEndpoint;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7225/api/");
        }
        public List<T> GetItems()
        {
            var response = client.GetAsync(apiEndpoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                return getResponse;
            }
            else
            {
                return null;
            }
        }

        public T GetItemById(int id)
        {
            var response = client.GetAsync($"{apiEndpoint}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<T>(responseContent);
                return getResponse;
            }
            else
            {
                return null;
            }
        }

        public string AddItem(T data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(apiEndpoint, content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateItem(T data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{apiEndpoint}/", content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
