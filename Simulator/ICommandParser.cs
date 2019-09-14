namespace Simulator
{
    public interface ICommandParser
    {
        CommandType Parse(string command);
    }
}