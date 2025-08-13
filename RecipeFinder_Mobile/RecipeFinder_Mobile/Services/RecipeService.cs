using RecipeFinder_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder_Mobile.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;

        public RecipeService()
        {
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.2.110:5146/api/") 
            };
        }

        public async Task<List<Recipe>> GetRecipesAsync(string ingredients)
        {
            var recipes = await _httpClient.GetFromJsonAsync<List<Recipe>>($"recipes?ingredients={ingredients}");
            return recipes ?? new List<Recipe>();
        }
    }
}
