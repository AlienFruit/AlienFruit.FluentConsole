using AlienFruit.FluentConsole;
using AlienFruit.FluentConsole.AsciiArt;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FConsole.GetInstance().GetAsciiArtBuilder()
                .DrawDemo(DemoPicture.DarthVader);

            FConsole.GetInstance().GetAsciiArtBuilder()
                .DrawDemo(DemoPicture.ApertureScience);

            FConsole.GetInstance().GetAsciiArtBuilder()
                .DrawDemo(DemoPicture.Alienfruit);

            FConsole.Color(ConsoleColor.Red).Write("This")
                .Color(ConsoleColor.Green).Write(" is")
                .Color(ConsoleColor.Blue).Write(" color")
                .ResetColor().Write(" text");

            FConsole.ReadKey();
        }
    }
}
