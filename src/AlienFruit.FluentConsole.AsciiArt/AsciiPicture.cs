using System;
using System.Collections.Generic;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public class AsciiPicture
    {
        public string[] Source { get; set; }

        public Style PictureStyle { get; set; }

        public IEnumerable<SelectionFormat> Formates { get; set; }

        public class Style
        {
            public ConsoleColor Background { get; set; }
            public ConsoleColor Foreground { get; set; }

            public int MarginTop { get; set; }
            public int MarginBottom { get; set; }
            public int MarginLeft { get; set; }
        }

        public class SelectionFormat
        {
            public int Row { get; set; }
            public int Start { get; set; }
            public int Length { get; set; }
            public ConsoleColor Foreground { get; set; }
            public ConsoleColor Background { get; set; }
            public int End => Start + Length;

            public bool Intersect(SelectionFormat value) 
                => Row == value.Row 
                && ((value.Start > Start && value.Start < End) || (value.End > Start && value.End < End) || (value.Start == Start && value.End == End));
        }

        public void Validate()
        {

        }

        
    }
}
