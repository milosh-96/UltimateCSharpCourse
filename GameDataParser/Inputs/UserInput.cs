
namespace GameDataParser.Inputs;

internal class UserInput
{
    public static string Enter(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public static bool IsNotNullAndEmpty(string input)
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