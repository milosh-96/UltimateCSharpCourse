namespace DiceRollGame;

static class UserInput
{
    public static int Get()
    {
        Console.WriteLine("Enter a number:");
        string userInput = Console.ReadLine();

        int parsedNumber = 0;
        if(int.TryParse(userInput, out parsedNumber)) { return parsedNumber; }

        Console.WriteLine("Wrong input");
        return UserInput.Get();
    }
}
