using System.Collections.Generic;

namespace Interlogica.Pastry.DTO
{
    public class ConfectioneryResponse : Confectionery
    {
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
