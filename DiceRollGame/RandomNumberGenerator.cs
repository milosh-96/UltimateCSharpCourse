namespace DiceRollGame;

static class RandomNumberGenerator
{
    public static int Generate()
    {
        return new Random().Next(GameRules.MinimumNumber, GameRules.MaximumNumber + 1);
    }
}
