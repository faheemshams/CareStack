﻿using Newtonsoft.Json;
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
        public List<T> GetData()
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
        public string CreateData(T data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(apiEndpoint, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return "Added a new entry.";
                }
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Allocate(int id, T data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{apiEndpoint}/{id}", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return "Allocated to the seat.";
                }
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Deallocate(T data)
        {

        }
        public void DeleteData(T data) { }
    }
}
