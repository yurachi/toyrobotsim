namespace Simulator
{
    public class Executor : IExecutor
    {
        public IRobot Unit { get; protected set; }

        public Executor(IRobot r)
        {
            this.Unit = r;
        }

        public void Execute(CommandType command, int x = -1, int y = -1, Direction d = Direction.NONE)
        {
            switch (command)
            {
                case CommandType.PLACE:
                    Unit.X = x;
                    Unit.Y = y;
                    Unit.Face = d;
                    break;

            }
        }
    }
}
