using CookieCookbookCourse.DataAccess;
using CookieCookbookCourse.Recipes.Ingredients;

namespace CookieCookbookCourse.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        return _stringsRepository.Read(filePath).Select(recipe => RecipeFromString(recipe)).ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = textualIds.Select(textualId =>
        {
            var id = int.Parse(textualId);
            return _ingredientsRegister.GetById(id);
        });

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = allRecipes.Select(recipe =>
        {
            return string.Join(Separator, recipe.Ingredients.Select(ingredient => ingredient.Id));
        }).ToList();


        //var recipesAsStrings = new List<string>();
        //foreach (var recipe in allRecipes)
        //{
        //    var allIds = new List<int>();
        //    foreach (var ingredient in recipe.Ingredients)
        //    {
        //        allIds.Add(ingredient.Id);
        //    }
        //    recipesAsStrings.Add(string.Join(Separator, allIds));
        //}

        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}
