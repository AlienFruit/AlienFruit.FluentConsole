using AlienFruit.Otml.Factories;
using System.IO;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public static class FluentConsoleExtensions
    {
        public static AsciiArtBuilder GetAsciiArtBuilder(this FluentConsole self)
        {
            return new AsciiArtBuilder()
                .UseParserFactory(x => new AsciiPictureParser(new OtmlParserFactory().GetParser(x), System.Console.ForegroundColor, System.Console.BackgroundColor))
                .UsePainter(new AsciiPicturePainter(
                    x => self.Color(x.foregroundColor).BackgroundColor(x.backgroundColor).Write(x.text),
                    () => self.ResetColor().ResetBackgroundColor()));
        }

        public static FluentConsole Draw(this FluentConsole self, Stream stream)
        {
            GetAsciiArtBuilder(self).Draw(stream);
            return self;
        }

        public static FluentConsole Draw(this FluentConsole self, string pictureFile)
        {
            GetAsciiArtBuilder(self).Draw(pictureFile);
            return self;
        }

        public static FluentConsole DrawDemo(this FluentConsole self, DemoPicture demoPicture)
        {
            GetAsciiArtBuilder(self).DrawDemo(demoPicture);
            return self;
        }
    }
}
