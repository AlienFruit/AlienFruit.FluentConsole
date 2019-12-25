using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FConsoleTests
{
    public class ConsoleTextWriter : TextWriter, IDisposable
    {
        private List<TextRange> textRanges = new List<TextRange>();

        public IEnumerable<TextRange> TextRanges => this.textRanges;

        public override Encoding Encoding { get { return Encoding.ASCII; } }
        override public void Write(string output)
        {
            this.textRanges.Add(new TextRange
            {
                BackgroundColor = Console.BackgroundColor,
                ForegroundColor = Console.ForegroundColor,
                EndOfLine = false,
                Text = output
            });
        }

        override public void WriteLine(string output)
        {
            this.textRanges.Add(new TextRange
            {
                BackgroundColor = Console.BackgroundColor,
                ForegroundColor = Console.ForegroundColor,
                EndOfLine = true,
                Text = output
            });
        }

        public class TextRange
        {
            public ConsoleColor ForegroundColor { get; set; }
            public ConsoleColor BackgroundColor { get; set; }
            public string Text { get; set; }
            public bool EndOfLine { get; set; }
        }

    }
}
