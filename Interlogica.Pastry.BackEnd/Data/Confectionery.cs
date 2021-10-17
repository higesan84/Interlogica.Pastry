using System.Collections.Generic;

namespace Interlogica.Pastry.BackEnd.Data
{
    public class Confectionery : DTO.Confectionery
    {
        public virtual ICollection<ConfectioneryIngredient> ConfectioneryIngredients { get; set; }
    }      
}
