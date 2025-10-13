using CookieCookbook.Readers;
using CookieCookbook.Shells;
using CookieCookbook.Writers;
using System.Text.Json;

namespace CookieCookbook;

internal class Program
{
    static void Main(string[] args)
    {
        Shell shell = new JsonShell();
        var ingredients = new List<Ingredient>()
        {
            new Ingredient() { Id = 1, Name = "Wheat flour" },
            new Ingredient() { Id = 2, Name = "Coconut flour" },
            new Ingredient() { Id = 3, Name = "Butter" },
            new Ingredient() { Id = 4, Name = "Chocolate" },
            new Ingredient() { Id = 5, Name = "Sugar" },
            new Ingredient() { Id = 6, Name = "Cardamom" },
            new Ingredient() { Id = 7, Name = "Cinnamon" },
            new Ingredient() { Id = 8, Name = "Cocoa powder" },
        };


        shell.Read();

        if(shell.Recipes.Count > 0)
        {
            Console.WriteLine("***** Existing recipes are: *****" + Environment.NewLine);
            for (int i = 0; i < shell.Recipes.Count; i++)
            {
                Console.WriteLine($"***** {i + 1} *****");

                foreach (int ingredientId in shell.Recipes[i])
                {
                    Ingredient ingredient = ingredients[ingredientId];
                    Console.WriteLine($"{ingredient.Name}.{ingredient.Instruction}.");
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
                Ingredient ingredient = ingredients.Where(item => item.Id == ingredientId).First();
                Console.WriteLine($"{ingredient.Name}.{ingredient.Instruction}.");
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
}
