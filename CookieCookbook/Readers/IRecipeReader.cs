using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Readers;
public interface IRecipeReader
{
    List<List<int>> Read(string fileName);
}
