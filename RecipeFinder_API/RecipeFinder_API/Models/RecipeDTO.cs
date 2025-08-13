namespace RecipeFinder.API.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int UsedIngredientCount { get; set; }
        public int MissedIngredientCount { get; set; }
    }
}
