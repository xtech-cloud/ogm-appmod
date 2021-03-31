
using System;
using XTC.oelMVCS;

namespace app
{
    class ConsoleLogger : Logger
    {
        protected override void trace(string _categoray, string _message)
        {
            Console.WriteLine("TRACE | {0} > {1}", _categoray, _message);
        }

        protected override void debug(string _categoray, string _message)
        {
            Console.WriteLine("DEBUG | {0} > {1}", _categoray, _message);
        }

        protected override void info(string _categoray, string _message)
        {
            Console.WriteLine("INFO | {0} > {1}", _categoray, _message);
        }

        protected override void warning(string _categoray, string _message)
        {
            Console.WriteLine("WARN | {0} > {1}", _categoray, _message);
        }

        protected override void error(string _categoray, string _message)
        {
            Console.WriteLine("ERROR | {0} > {1}", _categoray, _message);
        }

        protected override void exception(Exception _exception)
        {
            Console.WriteLine(_exception.ToString());
        }
    }//class
}//namespace
