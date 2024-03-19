using MiniProject.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Extensions
{
    public static partial class Extension
    {
        public static void Print(string message, MessageType type = MessageType.Success)
        {
            var backupColor = Console.ForegroundColor;

            switch (type)
            {
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            Console.Write(message);
            Console.ForegroundColor = backupColor;
        }

        public static void PrintLine(string message, MessageType type = MessageType.Success)
        {
            Print($"{message}\n", type);
        }

    }
}
