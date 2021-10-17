using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interlogica.Pastry.DTO;
using Interlogica.Pastry.FrontEnd.Data;
using Interlogica.Pastry.FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Interlogica.Pastry.FrontEnd.Pages.Admin
{
    public class CreatePastryModel : PageModel
    {
        private readonly IApiClient apiClient;

        public CreatePastryModel(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        [BindProperty]
        public Confectionery Confectionery { get; set; } = new Confectionery() { Name=string.Empty,BakingDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) };
        [BindProperty]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>() { new Ingredient() {Name="",Quantity=1,MeasureUnit="gr" } };


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await apiClient.PostConfectioneryAsync(Confectionery);
            foreach (var ing in Ingredients)
            {
                await apiClient.PostIngredientAsync(ing);
            }

            return Page();

        }


    }
}
