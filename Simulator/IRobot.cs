﻿namespace Simulator
{
    public interface IRobot
    {
        int X { get; set; }
        int Y { get; set; }
        Direction FacingDirection { get; set; }
    }
}