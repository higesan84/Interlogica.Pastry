using System;
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
    public class ConfectioneriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConfectioneriesController(AppDbContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        // GET: api/Confectioneries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfectioneryResponse>>> GetConfectioneries()
        {

            var confectioneries = await _context.Confectioneries.AsNoTracking()
                                                                .Include(c => c.ConfectioneryIngredients)
                                                                .ThenInclude(i => i.Ingredient)
                                                                .Select(c => c.MapConfectioneryResponse())
                                                                .ToListAsync();


            confectioneries = confectioneries.Where(c => !c.IsSpoiled).ToList();

            return confectioneries;
        }

        [HttpGet("spoiled")]
        public async Task<ActionResult<IEnumerable<ConfectioneryResponse>>> GetSpoiledConfectioneries()
        {

            var confectioneries = await _context.Confectioneries.AsNoTracking()
                                                                .Include(c => c.ConfectioneryIngredients)
                                                                .ThenInclude(i => i.Ingredient)
                                                                .Select(c => c.MapConfectioneryResponse())
                                                                .ToListAsync();

            confectioneries = confectioneries.Where(c => !c.IsSpoiled)
                                             .ToList();
            return confectioneries;
        }



        // GET: api/Confectioneries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfectioneryResponse>> GetConfectionery(int id)
        {


            var confectionery = await _context.Confectioneries.AsNoTracking()
                                                                .Include(c => c.ConfectioneryIngredients)
                                                                .ThenInclude(i => i.Ingredient)
                                                                .SingleOrDefaultAsync(c => c.Id == id);
            if (confectionery == null)
            {
                return NotFound();
            }

            return confectionery.MapConfectioneryResponse();
        }



        [HttpPost]
        public async Task<ActionResult<ConfectioneryResponse>> Post(DTO.Confectionery input)
        {
            var confectionery = new Data.Confectionery
            {
                BakingDate = input.BakingDate,
                Name = input.Name,
                Price = input.Price,
                Description = input.Description,

            };


            _context.Confectioneries.Add(confectionery);
            await _context.SaveChangesAsync();

            var result = confectionery.MapConfectioneryResponse();
            return CreatedAtAction(nameof(GetConfectionery), new { Id = result.Id }, result);

        }
        [HttpPost("delete/{id}")]
        public async Task<ActionResult<ConfectioneryResponse>> RemoveConfectionery(int id)
        {

            var confectionery = await _context.Confectioneries.FindAsync(id);
            if (confectionery == null)
                return NotFound();

            _context.Confectioneries.Remove(confectionery);
            await _context.SaveChangesAsync();
            return confectionery.MapConfectioneryResponse();

        }


        [HttpGet("{confectioneryId}/ingredients")]
        public async Task<ActionResult<IEnumerable<IngredientResponse>>> GetConfectioneryIngredient(int confectioneryId)
        {

            var confectionery = await _context.Confectioneries.FindAsync(confectioneryId);
            if (confectionery == null)
                return BadRequest(); // il dolce deve esserci


            List<IngredientResponse> ingredients = new List<IngredientResponse>();

  

            var ingredientsMiddle = await (from c in _context.Confectioneries.AsNoTracking()
                                           where c.Id == confectioneryId
                                           from cs in c.ConfectioneryIngredients
                                           from i in _context.Ingredients.AsNoTracking()
                                           where i.Id == cs.IngredientId
                                           select i).ToListAsync();

            ingredientsMiddle.ForEach(im => ingredients.Add(im.MapIngredientResponse()));

            return ingredients;

        }

        [HttpPost("{confectioneryId}/ingredients/{ingredientID}")]
        public async Task<int> PostConfectioneryIngredient(int confectioneryId,int ingredientId)
        {

            var ci = new ConfectioneryIngredient() { ConfectioneryId = confectioneryId, IngredientId = ingredientId };
            return await _context.SaveChangesAsync();

        }

    }
}
