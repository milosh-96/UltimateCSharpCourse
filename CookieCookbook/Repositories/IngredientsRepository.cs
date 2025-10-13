using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Repositories;
static class IngredientsRepository
{
    public static readonly List<Ingredient> Ingredients =
        [
            new Ingredient() { Id = 1, Name = "Wheat flour", Instructions = "Sieve. Add to other ingredients." },
            new Ingredient() { Id = 2, Name = "Coconut flour", Instructions = "Sieve.Add to other ingredients." },
            new Ingredient() { Id = 3, Name = "Butter", Instructions = "Melt on low heat.Add to other ingredients." },
            new Ingredient() { Id = 4, Name = "Chocolate", Instructions = "Melt in a water bath.Add to other ingredients." },
            new Ingredient() { Id = 5, Name = "Sugar", Instructions = "Add to other ingredients." },
            new Ingredient() { Id = 6, Name = "Cardamom", Instructions = "Take half a teaspoon. Add to other ingredients." },
            new Ingredient() { Id = 7, Name = "Cinnamon", Instructions = "Take half a teaspoon. Add to other ingredients." },
            new Ingredient() { Id = 8, Name = "Cocoa powder", Instructions = "Add to other ingredients." },
        ];
}
