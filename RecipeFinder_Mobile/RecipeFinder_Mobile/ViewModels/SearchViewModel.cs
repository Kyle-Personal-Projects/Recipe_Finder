using RecipeFinder_Mobile.Models;
using RecipeFinder_Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder_Mobile.ViewModels
{
    public class SearchViewModel : BindableObject
    {
        private string _ingredients;
        public string Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Recipe> Recipes { get; set; } = new();

        public ICommand SearchCommand { get; }

        private readonly RecipeService _recipeService;

        public SearchViewModel()
        {
            _recipeService = new RecipeService();
            SearchCommand = new Command(async () => await SearchRecipes());
        }

        private async Task SearchRecipes()
        {
            Recipes.Clear();
            var results = await _recipeService.GetRecipesAsync(Ingredients);
            foreach (var recipe in results)
            {
                Recipes.Add(recipe);
            }
        }
    }
}
