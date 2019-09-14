using System;
using System.Collections.Generic;
using System.Text;

namespace Simulator
{
    public class Dispatcher
    {
        public IParser Parser { get; private set; }

        public IExecutor Executor { get; set; }

        public Func<string> ReadLine { get; set; }

        public Dispatcher(IParser p, IExecutor e)
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
            switch (c)
            {
                case CommandType.PLACE:
                    Executor.Execute(c, this.Parser.XResult, this.Parser.YResult, this.Parser.DResult);
                    break;
                case CommandType.NOP:
                    return;
                default:
                    Executor.Execute(c);
                    break;
            }

        }


    }
}
