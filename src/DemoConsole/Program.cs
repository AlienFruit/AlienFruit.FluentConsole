using AlienFruit.FluentConsole;
using AlienFruit.FluentConsole.AsciiArt;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FConsole.GetInstance()
                .DrawDemo(DemoPicture.DarthVader)
                .DrawDemo(DemoPicture.ApertureScience)
                .DrawDemo(DemoPicture.Alienfruit)
                .DrawDemo(DemoPicture.RainbowPukeSkull)
                .DrawDemo(DemoPicture.AlienfruitLogo);

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
