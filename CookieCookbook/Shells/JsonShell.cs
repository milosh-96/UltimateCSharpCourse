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
        recipeParser = new JsonRecipeParser();
        FileExtension = "json";
    }

    public override void Write()
    {
        RecipeWriter.Write(Settings.RecipeFileName + "." + FileExtension, JsonSerializer.Serialize(Recipes), false);
    }
}
