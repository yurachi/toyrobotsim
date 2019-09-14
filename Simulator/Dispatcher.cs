using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    public class Dispatcher
    {
        public Robot Unit { get; set; }

        public CommandParser Parser { get; set; }

        public Func<string> ReadLine { get; set; }

        public Dispatcher(Robot r, CommandParser p)
        {
            this.Unit = r;
            this.Parser = p;
            this.ReadLine = Console.ReadLine;
        }

        public void MainLoop()
        {
            for (var nextCommand = this.ReadLine(); !string.IsNullOrEmpty(nextCommand); nextCommand = this.ReadLine())
            {
                Process(nextCommand);
            }
        }

        public void Process(string command)
        {

        }


    }
}
