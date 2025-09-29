using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame;
static class RandomNumberGenerator
{
    public static int Generate()
    {
        return new Random().Next(GameRules.MinimumNumber, GameRules.MaximumNumber + 1);
    }
}
