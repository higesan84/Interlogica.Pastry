using Interlogica.Pastry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interlogica.Pastry.BackEnd.Data
{
    public static class EntityExtensions
    {
        public static ConfectioneryResponse MapConfectioneryResponse(this Confectionery confectionery) =>
            new ConfectioneryResponse
            {
                Id = confectionery.Id,
                BakingDate = confectionery.BakingDate,
                Name = confectionery.Name,
                Price = confectionery.Price,
                Description = confectionery.Description,
                AvailableQuantity = confectionery.AvailableQuantity,

                Ingredients = confectionery.ConfectioneryIngredients?.Select(ci => new DTO.Ingredient()
                {
                    Id = ci.Ingredient.Id,
                    Name = ci.Ingredient.Name,
                }).ToList()
            };

        public static IngredientResponse MapIngredientResponse(this Ingredient ingredient) =>
            new IngredientResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                MeasureUnit = ingredient.MeasureUnit,
                Quantity = ingredient.Quantity
            };

    }
}
