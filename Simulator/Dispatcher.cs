using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    public class Dispatcher
    {
        public ICommandParser Parser { get; private set; }

        public IExecutor Executor { get; set; }

        public Func<string> ReadLine { get; set; }

        public Dispatcher(ICommandParser p, IExecutor e)
        {
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
