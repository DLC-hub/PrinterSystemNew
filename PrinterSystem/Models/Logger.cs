using System;
using PrinterSystem.Mediator;

namespace PrinterSystem.Models
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss} - {message}");
        }
    }
}