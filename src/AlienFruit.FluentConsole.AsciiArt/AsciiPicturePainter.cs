using System;
using System.Linq;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public class AsciiPicturePainter : IAsciiPicturePainter
    {
        private readonly Action<string> defaultColorConsoleWriter;
        private readonly Action<string, ConsoleColor> specialColorConsoleWriter;
        private readonly Action<ConsoleColor> foregroundColorSetter;
        private readonly Action<ConsoleColor> backgroundColorSetter;

        public AsciiPicturePainter(
            Action<string> defaultColorConsoleWriter, 
            Action<string, ConsoleColor> specialColorConsoleWriter,
            Action<ConsoleColor> foregroundColorSetter,
            Action<ConsoleColor> backgroundColorSetter)
        {
            this.defaultColorConsoleWriter = defaultColorConsoleWriter;
            this.specialColorConsoleWriter = specialColorConsoleWriter;
            this.foregroundColorSetter = foregroundColorSetter;
            this.backgroundColorSetter = backgroundColorSetter;
        }

        public void Draw(AsciiPicture picture)
        {
            var prewForegroundColor = System.Console.ForegroundColor;
            var prewFBackgroundColor = System.Console.BackgroundColor;

            this.foregroundColorSetter(picture.PictureStyle.Foreground);
            this.backgroundColorSetter(picture.PictureStyle.Background);

            for (int a = 0; a < picture.PictureStyle.MarginTop; a++)
                defaultColorConsoleWriter(Environment.NewLine);

            var formates = picture.Formates.ToLookup(x => x.Row);

            var leftPadding = "";
            if (picture.PictureStyle.MarginLeft > 0)
                leftPadding = leftPadding.PadRight(picture.PictureStyle.MarginLeft);

            for (int a = 0; a < picture.Source.Length; a++)
            {
                defaultColorConsoleWriter(leftPadding);

                if (!formates[a].Any())
                {
                    defaultColorConsoleWriter(picture.Source[a] + Environment.NewLine);
                    continue;
                }

                int prevPos = 0;
                formates[a].OrderBy(x => x.Start)
                    .ToList().ForEach(x =>
                    {
                        if (x.Start > prevPos)
                        {
                            var s = picture.Source[a].Substring(prevPos, x.Start - prevPos);
                            this.defaultColorConsoleWriter(s);
                        }

                        var str = picture.Source[a].Substring(x.Start, x.Length) + (x.End >= picture.Source[a].Length ? Environment.NewLine : string.Empty);
                        this.specialColorConsoleWriter(str, x.Color);
                        prevPos = x.End;
                    });

                if (prevPos < picture.Source[a].Length)
                {
                    var s = picture.Source[a].Substring(prevPos, picture.Source[a].Length - prevPos) + Environment.NewLine;
                    this.defaultColorConsoleWriter(s);
                }
            }

            for (int a = 0; a < picture.PictureStyle.MarginBottom; a++)
                this.defaultColorConsoleWriter(Environment.NewLine);

            this.foregroundColorSetter(prewForegroundColor);
            this.backgroundColorSetter(prewFBackgroundColor);
        }
    }
}
