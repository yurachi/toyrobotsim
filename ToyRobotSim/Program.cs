 using System;

 namespace ToyRobotSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("Commands:");
            Console.WriteLine("- PLACE X,Y,F   where X and Y between 0 and 4 and F is one of [NORTH, SOUTH, EAST, WEST]");
            Console.WriteLine("- MOVE");
            Console.WriteLine("- LEFT");
            Console.WriteLine("- RIGHT");
            Console.WriteLine("- REPORT");
            Console.WriteLine("empty command to exit");
            Console.WriteLine();

            var robot = new Simulator.Robot();
            var parser = new Simulator.Parser(robot);
            var executor = new Simulator.Executor(robot);
            var dispatcher = new Simulator.Dispatcher(parser, executor);
            dispatcher.MainLoop();
        }
    }
}
