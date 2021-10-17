using System.ComponentModel.DataAnnotations;

namespace Interlogica.Pastry.DTO
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public string MeasureUnit { get; set; } 

    }
}
