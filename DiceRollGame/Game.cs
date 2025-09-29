namespace DiceRollGame;

class Game
{
    private int _userGuess;
    private int _goalNumber;
    private int _chances = GameRules.Chances;
    public void Play()
    {
        _goalNumber = RandomNumberGenerator.Generate();

        Console.WriteLine($"Welcome! Try to guess the number between 1 and 6. {_goalNumber}");

       while(_chances > 0)
        {
            _userGuess = UserInput.Get();

            if(_userGuess == _goalNumber)
            {
                Console.WriteLine("You win.");
                break;
            }
            _chances--;
            Console.WriteLine("Wrong number!");
        }

        if (_chances == 0) { Console.WriteLine($"Your lose!"); }
    }
}
