using Interlogica.Pastry.DTO;

namespace Interlogica.Pastry.BackEnd.Data
{
    public class ConfectioneryIngredient
    {

        public int ConfectioneryId { get; set; }
        public Confectionery Confectionery { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
