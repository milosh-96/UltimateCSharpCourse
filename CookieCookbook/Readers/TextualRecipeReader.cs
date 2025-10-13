using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Readers;
public class TextualRecipeReader : IRecipeReader
{
    public List<List<int>> Read(string fileName)
    {
        List<List<int>> recipes = new List<List<int>>();

        try
        {
            var fileReader = new StreamReader(fileName);
            string recipeLine = fileReader.ReadLine();
            while (recipeLine != null)
            {
                List<int> temp = new List<int>();

                foreach (string stringId in recipeLine.Split(','))
                {
                    int id;
                    if (int.TryParse(stringId, out id))
                    {
                        temp.Add(id);
                    }
                }

                recipes.Add(temp);
                recipeLine = fileReader.ReadLine();
            }
            fileReader.Close();
        }
        catch(FileNotFoundException ex)
        {
            
        }
        return recipes;
    }
}
