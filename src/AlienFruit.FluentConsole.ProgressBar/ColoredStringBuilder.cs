using System;
using System.Collections.Generic;

namespace AlienFruit.FluentConsole.ProgressBar
{
    internal class ColoredStringBuilder
    {

        private readonly List<(ConsoleColor color, string text, bool newLine)> values = new List<(ConsoleColor color, string text, bool newLine)>();


        public void Append(ConsoleColor color, string text)
        {
            values.Add((color, text, false));
        }

        public void Print(Action<(ConsoleColor color, string text, bool newLine)> printItem)
        {
            foreach (var item in values)
            {
                printItem(item);
            }
        }
    }
}
