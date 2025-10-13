using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Writers;
static class RecipeWriter
{
    public static void Write(string fileName, string contents, bool append = true)
    {
        StreamWriter streamWriter = new StreamWriter(fileName, append);
        streamWriter.WriteLine(contents);
        streamWriter.Close();
    }
}
