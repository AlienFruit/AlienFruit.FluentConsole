using AlienFruit.FluentConsole;
using AlienFruit.FluentConsole.AsciiArt;
using AlienFruit.FluentConsole.ProgressBar;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var total = 100;
            for (int i = 0; i < total; i++)
            {
                Task.Delay(5).Wait();
                FConsole.GetInstance().DrawProgressBar(i, total, elapsed: TimeSpan.FromMinutes(2));
            }

            FConsole.GetInstance()
                .DrawDemo(DemoPicture.DarthVader)
                .DrawDemo(DemoPicture.ApertureScience)
                .DrawDemo(DemoPicture.Alienfruit)
                .DrawDemo(DemoPicture.RainbowPukeSkull)
                .DrawDemo(DemoPicture.AlienfruitLogo);

            FConsole.Color(ConsoleColor.Red).Write("This")
                .Color(ConsoleColor.Green).Write(" is a ")
                .Color(ConsoleColor.Blue).BackgroundColor(ConsoleColor.DarkGray).Write("color")
                .ResetColors().Write(" text");


            FConsole.ReadKey();
        }
    }
}
