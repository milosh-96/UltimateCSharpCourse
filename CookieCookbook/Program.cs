using CookieCookbook.Readers;
using CookieCookbook.Repositories;
using CookieCookbook.Shells;
using CookieCookbook.Writers;
using System.Text.Json;

namespace CookieCookbook;

internal class Program
{
    static void Main(string[] args)
    {
        Shell shell = Settings.RecipeFileFormat == Enums.FileFormat.Txt ? new TxtShell() : new JsonShell();
        var ingredients = IngredientsRepository.Ingredients;

        shell.LoadRecipes();

        if(shell.Recipes != null && shell.Recipes.Count > 0)
        {
            Console.WriteLine("***** Existing recipes are: *****" + Environment.NewLine);
            for (int i = 0; i < shell.Recipes.Count; i++)
            {
                Console.WriteLine($"***** {i + 1} *****");

                foreach (int ingredientId in shell.Recipes[i])
                {
                    PrintIngredientsOfRecipe(ingredients, ingredientId);
                }
            }
        }

        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }

        int userInput;

        List<int> recipe = new List<int>();
        do
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            int.TryParse(Console.ReadLine(), out userInput);

            if (userInput != null && ingredients.Any(ingredient => ingredient.Id == userInput))
            {
                recipe.Add(userInput);
            }
        }
        while (userInput > 0);

        if (recipe.Count > 0)
        {
            Console.WriteLine("Recipe added:");
            shell.Recipes.Add(recipe);

            foreach (int ingredientId in recipe)
            {
                PrintIngredientsOfRecipe(ingredients, ingredientId);
            }
            shell.Write();

        }
        else
        {
            Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static void PrintIngredientsOfRecipe(List<Ingredient> ingredients, int ingredientId)
    {
        Ingredient ingredient = ingredients[ingredientId - 1];
        Console.WriteLine($"{ingredient.Name}.{ingredient.Instructions}.");
        Console.WriteLine();
    }
}
