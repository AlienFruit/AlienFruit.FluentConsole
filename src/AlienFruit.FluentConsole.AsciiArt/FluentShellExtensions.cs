using AlienFruit.Otml.Factories;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public static class FluentShellExtensions
    {
        public static AsciiArtBuilder GetAsciiArtBuilder(this FConsole.FluentConsole self)
        {
            return new AsciiArtBuilder()
                .UseParserFactory(x => new AsciiPictureParser(new OtmlParserFactory().GetParser(x), System.Console.ForegroundColor, System.Console.BackgroundColor))
                .UsePainter(new AsciiPicturePainter(
                    x => self.Color(x.foregroundColor).BackgroundColor(x.backgroundColor).Write(x.text),
                    () => self.ResetColor().ResetBackgroundColor()));
        }
    }
}
