using AlienFruit.FluentConsole;
using AlienFruit.FluentConsole.AsciiArt;

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

            FConsole.ReadKey();
        }
    }
}
