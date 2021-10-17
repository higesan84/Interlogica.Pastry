using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Interlogica.Pastry.DTO;
using Newtonsoft.Json;
using System.Text;

namespace Interlogica.Pastry.FrontEnd.Services
{
    public class ApiClient : IApiClient
    {

        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> PostIngredientAsync(Ingredient ingredient)
        {
            var response = await this._httpClient.PostAsJsonAsync($"/api/ingredients", ingredient);
            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<List<ConfectioneryResponse>> GetConfectioneriesAsync()
        {
            var response = await _httpClient.GetAsync("api/Confectioneries");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ConfectioneryResponse>>();

        }

        public async Task<ConfectioneryResponse> GetConfectioneryAsync(int id)
        {

            var response = await _httpClient.GetAsync($"api/Confectioneries/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ConfectioneryResponse>();

        }

        public async Task<List<IngredientResponse>> GetConfectioneryIngredientsAsync(int confectioneryId)
        {
            var response = await _httpClient.GetAsync("api/Confectioneries/{id}/ingredients");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<IngredientResponse>>();
        }


        public async Task<List<IngredientResponse>> GetIngredientsAsync()
        {
            var response = await _httpClient.GetAsync("api/Ingredients");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<IngredientResponse>>();
        }

        public async Task<List<ConfectioneryResponse>> GetSpoiledConfectioneriesAsync()
        {
            var response = await _httpClient.GetAsync("api/Confectioneries/spoiled");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<ConfectioneryResponse>>();

        }

        public async Task<bool> PostConfectioneryAsync(Confectionery confectionery)
        {
            var json = JsonConvert.SerializeObject(confectionery);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
            var response = await _httpClient.PostAsync("api/Confectioneries", stringContent);
            return true;
        }

        

    }
}
