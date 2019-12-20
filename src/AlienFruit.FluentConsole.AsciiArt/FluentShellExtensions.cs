using AlienFruit.Otml.Factories;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public static class FluentShellExtensions
    {
        public static AsciiArtBuilder GetAsciiArtBuilder(this Console.FluentConsole self)
        {
            return new AsciiArtBuilder()
                .UseParserFactory(x => new AsciiPictureParser(new OtmlParserFactory().GetParser(x), System.Console.ForegroundColor, System.Console.BackgroundColor))
                .UsePainter(new AsciiPicturePainter(
                    x => System.Console.Write(x),
                    (value, color) => self.Color(color).Write(value),
                    x => self.Color(x),
                    x => self.BackgroundColor(x)));
        }
    }
}
