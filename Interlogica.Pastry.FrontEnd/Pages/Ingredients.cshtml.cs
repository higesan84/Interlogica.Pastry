using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interlogica.Pastry.DTO;
using Interlogica.Pastry.FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interlogica.Pastry.FrontEnd.Pages
{
    public class IngredientsModel : PageModel
    {

        private readonly IApiClient _apiClient;

        public IngredientsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public ConfectioneryResponse Confectionery { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            Confectionery = await _apiClient.GetConfectioneryAsync(id);

            if (Confectionery == null)
                return RedirectToPage("/Index");

            return null;


        }


    }
}
