using System;

namespace Trivia
{
    public class ConsoleOutputAdapter : IOutputAdapter
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}