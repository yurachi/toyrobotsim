namespace Simulator
{
    public class Calculator
    {
        public static void CalculateMove(ref int newX, ref int newY, Direction d)
        {
            switch (d)
            {
                case Direction.EAST:
                    ++newX;
                    break;
                case Direction.SOUTH:
                    --newY;
                    break;
                case Direction.WEST:
                    --newX;
                    break;
                case Direction.NORTH:
                    ++newY;
                    break;
            }
        }

        public static void CalculateTurn(ref Direction newDirection, CommandType leftOrRight)
        {
            var delta = (leftOrRight == CommandType.LEFT) ? -1 : 1;
            var result = ((int)newDirection + delta) % 4;
            if (result == 0) result = 4;
            newDirection = (Direction) result;
        }
    }
}