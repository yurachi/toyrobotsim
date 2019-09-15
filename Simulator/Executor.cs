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

                case CommandType.MOVE:
                    var newX = Unit.X;
                    var newY = Unit.Y;
                    Calculator.CalculateMove(ref newX, ref newY, Unit.Face);
                    Unit.X = newX;
                    Unit.Y = newY;
                    break;

                case CommandType.LEFT:
                    var newDirection = Unit.Face;
                    Calculator.CalculateTurn(ref newDirection, CommandType.LEFT);
                    Unit.Face = newDirection;
                    break;

                case CommandType.RIGHT:
                    newDirection = Unit.Face;
                    Calculator.CalculateTurn(ref newDirection, CommandType.RIGHT);
                    Unit.Face = newDirection;
                    break;

            }
        }
    }
}
