 using Interlogica.Pastry.DTO;
using Interlogica.Pastry.FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Interlogica.Pastry.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        protected readonly IApiClient _apiClient;

        public bool IsAdmin { get; set; }


        public IndexModel(IApiClient apiClient, ILogger<IndexModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public IEnumerable<IngredientResponse> Ingredients { get; set; }

        public IEnumerable<ConfectioneryResponse> Confectionery { get; set; }


        public async Task OnGetAsync()
        {
            IsAdmin = User.IsAdmin();
            var ingredients = await _apiClient.GetIngredientsAsync();
            var confectionery = await _apiClient.GetConfectioneriesAsync();

            Ingredients = ingredients.OrderBy(i => i.Name);

            Confectionery = confectionery.Where(c => !c.IsSpoiled);



        }
    }
}
