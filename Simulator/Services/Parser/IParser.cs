namespace Simulator
{
    public interface IParser
    {
        CommandType Parse(string command);
        Direction DResult { get; }
        int YResult { get; }
        int XResult { get; }
    }
}