using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interlogica.Pastry.BackEnd.Data;
using Interlogica.Pastry.DTO;

namespace Interlogica.Pastry.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientsController(AppDbContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientResponse>>> GetIngredients()
        {
            var ingredients = await _context.Ingredients.AsNoTracking()
                .Select(i => i.MapIngredientResponse())
                .ToListAsync();

            return ingredients;
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientResponse>> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient.MapIngredientResponse();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<IngredientResponse>> Post(DTO.Ingredient input)
        {
            // Check if the ingredient already exists
            var existingIngredient = await _context.Ingredients
                .Where(a => a.Id == input.Id)
                .FirstOrDefaultAsync();

            if (existingIngredient != null)
            {
                return Conflict(input);
            }

            var ingredient = new Data.Ingredient
            {
                Name = input.Name,
            };

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            var result = ingredient.MapIngredientResponse();

            return CreatedAtAction(nameof(Post), new { username = result.Name }, result);
        }





    }
}
