using Interlogica.Pastry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interlogica.Pastry.FrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<ConfectioneryResponse>> GetConfectioneriesAsync();
        Task<ConfectioneryResponse> GetConfectioneryAsync(int id);
        Task<List<IngredientResponse>> GetIngredientsAsync();
        Task<List<IngredientResponse>> GetConfectioneryIngredientsAsync(int confectioneryId);

        Task<bool> PostConfectioneryAsync(Confectionery confectionery);

        Task<bool> PostIngredientAsync(Ingredient ingredient);


    }
}
