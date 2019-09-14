using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    public class Dispatcher
    {
        public IRobot Unit { get; private set; }

        public ICommandParser Parser { get; private set; }

        public IExecutor Executor { get; set; }

        public Func<string> ReadLine { get; set; }

        public Dispatcher(IRobot r, ICommandParser p, IExecutor e)
        {
            this.Unit = r;
            this.Parser = p;
            this.Executor = e;
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
            var c = this.Parser.Parse(command);
            if (c == CommandType.NOP)
                return;
        }


    }
}
