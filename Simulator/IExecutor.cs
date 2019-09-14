namespace Simulator
{
    public interface IExecutor
    {
        void Execute(CommandType command, int x = -1, int y = -1, Direction d = Direction.NONE);
    }
}