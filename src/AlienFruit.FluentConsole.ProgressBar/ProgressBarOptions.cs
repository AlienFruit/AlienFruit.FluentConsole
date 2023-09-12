using System;

namespace AlienFruit.FluentConsole.ProgressBar
{
    public class ProgressBarOptions
    {
        public char Character { get; set; }
        public ConsoleColor Color { get; set; }
        public char BackgroundChar { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public bool AutoHide { get; set; }
        public PercentLocation Location { get; set; }
        public int Accuracy { get; set; }
        public BarSize BarSize {get;set;}

        public static ProgressBarOptions Default => new ProgressBarOptions
        {
            Character = '\u2588',
            Color = ConsoleColor.Yellow,
            BackgroundChar = '\u2593',
            BackgroundColor = ConsoleColor.DarkGray,
            AutoHide = false,
            Location = PercentLocation.Left,
            Accuracy = 0,
            BarSize = BarSize.Full
        };
    }
}
