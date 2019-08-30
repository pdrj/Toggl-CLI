using System;

namespace TogglCmdLine.Logging
{
    public sealed class ConsoleLogger
    {
        public static void Log(string message)
        {
            if(Env.EnvConfig.DEBUG_ENABLED) Console.WriteLine(message);
        }
    }
}