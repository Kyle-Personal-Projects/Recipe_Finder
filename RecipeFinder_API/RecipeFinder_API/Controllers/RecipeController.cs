using Microsoft.AspNetCore.Mvc;
using RecipeFinder_API.Models;
using RecipeFinder.API.Services;

namespace RecipeFinder_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipesController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery] string ingredients)
        {
            if (string.IsNullOrWhiteSpace(ingredients))
                return BadRequest("Please provide at least one ingredient.");

            var recipes = await _recipeService.GetRecipesByIngredientsAsync(ingredients);
            return Ok(recipes);
        }
    }
}
