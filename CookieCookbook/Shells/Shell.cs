using CookieCookbook.Readers;
using CookieCookbook.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Shells;
public abstract class Shell
{
    public List<List<int>> Recipes { get; set; } = new List<List<int>>();
    public IRecipeReader recipeReader;
    public string FileExtension { get; set; } = "txt";
    
    public virtual void Read()
    {
        Recipes = recipeReader.Read(Settings.RecipeFileName + "." + FileExtension);
    }

    public virtual void Write()
    {
        RecipeWriter.Write(Settings.RecipeFileName + "." + FileExtension, string.Join(',', Recipes.Last()));
    }
}
