using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib
{
    public enum LogLevel
    {
        Temp,
        Warning,
        Error
    }

    public class Logger
    {
        public static void Log(LogLevel level, string log)
        {
            switch(level)
            {
                case LogLevel.Temp:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                case LogLevel.Warning:
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                }
                case LogLevel.Error:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                default:
                    break;
            }

            
            Console.WriteLine($"[Logger] [{DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()}] {level.ToString()} {log}");
        }
    }
}
