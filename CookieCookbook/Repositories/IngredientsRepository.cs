using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Repositories;
static class IngredientsRepository
{
    public static readonly List<Ingredient> Ingredients =
        [
            new Ingredient() { Id = 1, Name = "Wheat flour" },
            new Ingredient() { Id = 2, Name = "Coconut flour" },
            new Ingredient() { Id = 3, Name = "Butter" },
            new Ingredient() { Id = 4, Name = "Chocolate" },
            new Ingredient() { Id = 5, Name = "Sugar" },
            new Ingredient() { Id = 6, Name = "Cardamom" },
            new Ingredient() { Id = 7, Name = "Cinnamon" },
            new Ingredient() { Id = 8, Name = "Cocoa powder" },
        ];
}
