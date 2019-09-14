namespace Simulator
{
    public interface IRobot
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Face { get; set; }
        bool IsPlaced { get; set; }
    }
}