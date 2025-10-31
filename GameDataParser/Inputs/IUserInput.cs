namespace GameDataParser.Inputs;

public interface IUserInput
{
    string Get(string message);
    bool IsNotNullAndEmpty();
}