using System;
using System.Linq;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public class AsciiPicturePainter : IAsciiPicturePainter
    {
        private readonly Action<(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)> consoleWriter;
        private readonly Action afterDrawAction;

        public AsciiPicturePainter(Action<(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)> consoleWriter,
            Action afterDrawAction)
        {
            this.consoleWriter = consoleWriter;
            this.afterDrawAction = afterDrawAction;
        }

        public void Draw(AsciiPicture picture)
        {
            void Write(string value) => this.consoleWriter((value, picture.PictureStyle.Foreground, picture.PictureStyle.Background));
            void WriteColor(string value, ConsoleColor color) => this.consoleWriter((value, color, picture.PictureStyle.Background));
             
            for (int a = 0; a < picture.PictureStyle.MarginTop; a++)
                Write(Environment.NewLine);

            var formates = picture.Formates.ToLookup(x => x.Row);

            var leftPadding = "";
            if (picture.PictureStyle.MarginLeft > 0)
                leftPadding = leftPadding.PadRight(picture.PictureStyle.MarginLeft);

            for (int a = 0; a < picture.Source.Length; a++)
            {
                Write(leftPadding);

                if (!formates[a].Any())
                {
                    Write(picture.Source[a] + Environment.NewLine);
                    continue;
                }

                int prevPos = 0;
                formates[a].OrderBy(x => x.Start)
                    .ToList().ForEach(x =>
                    {
                        if (x.Start > prevPos)
                        {
                            var s = picture.Source[a].Substring(prevPos, x.Start - prevPos);
                            Write(s);
                        }

                        var str = picture.Source[a].Substring(x.Start, x.Length) + (x.End >= picture.Source[a].Length ? Environment.NewLine : string.Empty);
                        WriteColor(str, x.Color);
                        prevPos = x.End;
                    });

                if (prevPos < picture.Source[a].Length)
                {
                    var s = picture.Source[a].Substring(prevPos, picture.Source[a].Length - prevPos) + Environment.NewLine;
                    Write(s);
                }
            }

            for (int a = 0; a < picture.PictureStyle.MarginBottom; a++)
                Write(Environment.NewLine);

            this.afterDrawAction?.Invoke();
        }
    }
}
