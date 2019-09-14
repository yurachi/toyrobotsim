namespace Simulator
{
    public interface IParser
    {
        CommandType Parse(string command);
    }
}