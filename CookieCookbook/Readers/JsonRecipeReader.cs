using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieCookbook.Readers;
public class JsonRecipeReader : IRecipeReader
{
    public List<List<int>> Read(string fileName)
    {
        List<List<int>> recipes = new List<List<int>>();

        try
        {
            var fileReader = new StreamReader(fileName);

            string recipeJson = fileReader.ReadToEnd();
            recipes = JsonSerializer.Deserialize<List<List<int>>>(recipeJson);
            fileReader.Close();
        }
        catch (Exception ex)
        {

        }
        return recipes;
    }
}
