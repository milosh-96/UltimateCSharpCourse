using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Writers;
static class RecipeWriter
{
    public static void Write(string fileName, string contents)
    {
        StreamWriter streamWriter = new StreamWriter(fileName, true);
        streamWriter.WriteLine(contents);
        streamWriter.Close();
    }
}
