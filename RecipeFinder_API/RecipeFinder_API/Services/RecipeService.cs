using RecipeFinder.API.Models;
using System.Net.Http.Json;

namespace RecipeFinder.API.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public RecipeService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<RecipeDto>> GetRecipesByIngredientsAsync(string ingredients)
        {
            string apiKey = _config["Spoonacular:ApiKey"];
            string url = $"https://api.spoonacular.com/recipes/findByIngredients" +
                         $"?ingredients={ingredients}&number=5&apiKey={apiKey}";

            var recipes = await _httpClient.GetFromJsonAsync<List<RecipeDto>>(url);
            return recipes ?? new List<RecipeDto>();
        }
    }
}
