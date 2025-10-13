using CookieCookbook.Readers;
using CookieCookbook.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieCookbook.Shells;
public class JsonShell : Shell
{
    public JsonShell()
    {
        recipeReader = new JsonRecipeReader();
        FileExtension = "json";
    }

    public override void Write()
    {
        var temp = new List<string>();

        foreach(var recipe in Recipes)
        {
            temp.Add(string.Join(',', recipe));
        }

        RecipeWriter.Write(Settings.RecipeFileName + "." + FileExtension, JsonSerializer.Serialize(Recipes));
    }
}
