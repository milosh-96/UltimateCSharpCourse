using CookieCookbookCourse.Recipes;
using CookieCookbookCourse.Recipes.Ingredients;

namespace CookieCookbookCourse.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}



