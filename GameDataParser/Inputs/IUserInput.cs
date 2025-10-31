namespace GameDataParser.Inputs;

public interface IUserInput
{
    string Enter(string message);
    bool IsNotNullAndEmpty();
}