namespace GameDataParser.Inputs;

public class UserInput : IUserInput
{
    private string input;
    public string Get(string message)
    {
        Console.WriteLine(message);
        input = Console.ReadLine();
        return this.input;
    }

    public bool IsNotNullAndEmpty()
    {
        if (input == null)
        {
            Console.WriteLine("File name cannot be null.");
            return false;
        }
        if (input == "")
        {
            Console.WriteLine("File name cannot be empty.");
            return false;
        }

        return true;
    }
}
