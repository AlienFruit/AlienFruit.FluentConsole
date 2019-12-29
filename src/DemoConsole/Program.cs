using AlienFruit.FluentConsole;
using AlienFruit.FluentConsole.AsciiArt;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.DarthVader);
            FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.ApertureScience);
            FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.Alienfruit);
            FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.RainbowPukeSkull);
            FConsole.GetInstance().GetAsciiArtBuilder().DrawDemo(DemoPicture.AlienfruitLogo);

            FConsole.Color(ConsoleColor.Red).Write("This")
                .Color(ConsoleColor.Green).Write(" is")
                .Color(ConsoleColor.Blue).BackgroundColor(ConsoleColor.DarkGray).Write(" color")
                .ResetColors().Write(" text");

            FConsole.WriteLine("This is a text")
                .Color(ConsoleColor.Green).WriteLine("This is a green text")
                .BackgroundColor(ConsoleColor.Red).WriteLine("This is a green text with red background")
                .ResetColors()
                .WriteLine("This is a white text");

            FConsole.ReadKey();
        }
    }
}
