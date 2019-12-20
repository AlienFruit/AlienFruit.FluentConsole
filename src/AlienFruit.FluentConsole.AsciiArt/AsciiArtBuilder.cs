using System;
using System.IO;
using System.Reflection;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public class AsciiArtBuilder
    {
        private IAsciiPicturePainter painter;
        private Func<Stream, IAsciiPictureParser> parserFactory;

        public AsciiArtBuilder UsePainter(IAsciiPicturePainter painter)
        {
            this.painter = painter;
            return this;
        }

        public AsciiArtBuilder UseParserFactory(Func<Stream, IAsciiPictureParser> parserFactory)
        {
            this.parserFactory = parserFactory;
            return this;
        }

        public void Draw(Stream stream)
        {
            if (this.painter is null)
                throw new InvalidOperationException("Should select IAsciiPicturePainter before invoke this method");

            if(this.parserFactory is null)
                throw new InvalidOperationException("Should select parser factory before invoke this method");

            using (var parser = this.parserFactory.Invoke(stream))
                this.painter.Draw(parser.GetPicture());
        }

        public void Draw(string pictureFile)
        {
            using (var stream = File.OpenRead(pictureFile))
                Draw(stream);
        }

        public void DrawDemo(DemoPicture demoPicture)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream($"AlienFruit.Shell.AsciiArt.AsciiPictures.{demoPicture}.otml"))
                Draw(stream);
        }
    }
}
