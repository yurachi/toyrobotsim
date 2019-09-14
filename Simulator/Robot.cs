using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Simulator
{
    public class Robot : IRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Face { get; set; }
        public bool IsPlaced { get; set; }
    }
}
