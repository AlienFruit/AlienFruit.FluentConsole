using AlienFruit.Otml;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public class AsciiPictureParser : IAsciiPictureParser
    {
        private readonly IParser otmlParser;
        private readonly ConsoleColor defaultForeground;
        private readonly ConsoleColor defaultBackground;

        private bool disposed = false;

        public AsciiPictureParser(IParser parser, ConsoleColor defaultForeground, ConsoleColor defaultBackground)
        {
            this.otmlParser = parser;
            this.defaultForeground = defaultForeground;
            this.defaultBackground = defaultBackground;
        }

        public AsciiPicture GetPicture()
        {
            var otmlDom = this.otmlParser.Parse();
            var model = new AsciiPicture
            {
                PictureStyle = new AsciiPicture.Style
                {
                    Background = this.defaultBackground,
                    Foreground = this.defaultForeground
                }
            };
            var formates = new List<AsciiPicture.SelectionFormat>();

            foreach (var node in otmlDom)
            {
                if (node.Name == "source")
                {
                    var value = node.Children.Where(x => x.Type == NodeType.Value).SingleOrDefault()
                        ?? throw new ArgumentException("The source node doen't contain a value");
                    model.Source = value.Value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }

                if(node.Name == "style")
                {
                    foreach (var styleNode in node.Children)
                    {           
                        var background = ParseProperty(styleNode, "background", x => (Enum.TryParse<ConsoleColor>(x, true, out var result), result));
                        if (background.success)
                            model.PictureStyle.Background = background.result;

                        var foreground = ParseProperty(styleNode, "foreground", x => (Enum.TryParse<ConsoleColor>(x, true, out var result), result));
                        if (foreground.success)
                            model.PictureStyle.Foreground = foreground.result;

                        var marginTop = ParseProperty(styleNode, "margin-top", x => (int.TryParse(x, out var result), result));
                        if (marginTop.success)
                            model.PictureStyle.MarginTop = marginTop.result;

                        var marginBottom = ParseProperty(styleNode, "margin-bottom", x => (int.TryParse(x, out var result), result));
                        if (marginBottom.success)
                            model.PictureStyle.MarginBottom = marginBottom.result;

                        var marginLeft = ParseProperty(styleNode, "margin-left", x => (int.TryParse(x, out var result), result));
                        if (marginLeft.success)
                            model.PictureStyle.MarginLeft = marginLeft.result;
                    }
                }

                if (node.Name == "select")
                {
                    var format = ParseSelectionFormat(node);
                    if (format is null)
                    {
                        format = new AsciiPicture.SelectionFormat();
                        foreach (var selectNode in node.Children)
                        {
                            var row = ParseProperty(selectNode, "row", x => (int.TryParse(x, out var result), result));
                            if (row.success)
                                format.Row = row.result;

                            var start = ParseProperty(selectNode, "start", x => (int.TryParse(x, out var result), result));
                            if (start.success)
                                format.Start = start.result;

                            var length = ParseProperty(selectNode, "length", x => (int.TryParse(x, out var result), result));
                            if (length.success)
                                format.Length = length.result;

                            var color = ParseProperty(selectNode, "color", x => (Enum.TryParse<ConsoleColor>(x, true, out var result), result));
                            if (color.success)
                                format.Color = color.result;
                        }
                    }
                    formates.Add(format);
                }
            }

            if (model.Source is null)
                throw new ArgumentException("@source node was not found, incorrent AsciiPicture format");

            model.Formates = formates;
            return model;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static (T result, bool success) ParseProperty<T>(OtmlNode node, string propertyName, Func<string, (bool success, T value)> valueParser)
        {
            if (node.Name != propertyName)
                return (default, false);
            
            var value = node.Children.Where(x => x.Type == NodeType.Value)
                .SingleOrDefault() ?? throw new ArgumentException($"{propertyName} doesn't conain any values");
            if (value.Value == "default")
                return (default, false);

            var parseResult = valueParser(value.Value);
            if(!parseResult.success)
                throw new ArgumentException($"The value '{value.Value}' cannot be parsed as {typeof(T).Name}");

            return (parseResult.value, true);
        }

        private static AsciiPicture.SelectionFormat ParseSelectionFormat(OtmlNode node)
        {
            
            var values = node.Children.Where(x => x.Type == NodeType.Value).ToList();

            if (!values.Any())
                return default;

            if (values.Count != 4)
                throw new ArgumentException($"select node  should contains 4 value: row, start, end, color");

            if(!int.TryParse(values[0].Value, out var row))
                throw new ArgumentException($"value '{values[0].Value}' cannot be parsed as unt value");

            if (!int.TryParse(values[1].Value, out var start))
                throw new ArgumentException($"value '{values[1].Value}' cannot be parsed as int value");

            if (!int.TryParse(values[2].Value, out var length))
                throw new ArgumentException($"value '{values[2].Value}' cannot be parsed as int value");

            if (!Enum.TryParse<ConsoleColor>(values[3].Value, true, out var color))
                throw new ArgumentException($"value '{values[3].Value}' cannot be parsed as ConsoleColor value");

            return new AsciiPicture.SelectionFormat
            {
                Row = row,
                Start = start,
                Length = length,
                Color = color
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                this.otmlParser.Dispose();

            disposed = true;
        }
    }
}
