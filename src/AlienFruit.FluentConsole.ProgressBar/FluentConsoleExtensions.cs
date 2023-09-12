using System;
using System.Text;

namespace AlienFruit.FluentConsole.ProgressBar
{
    public static class FluentConsoleExtensions
    {
        public static FluentConsole DrawProgressBar(this FluentConsole self, 
            int current, int total, string message = null, TimeSpan? elapsed = null, ProgressBarOptions options = null)
        {
            if (options == null)
            {
                options = ProgressBarOptions.Default;
            }

            if (current + 1 < total)
            {
                Console.CursorVisible = false;
            }

            Console.SetCursorPosition(0, Console.CursorTop);

            GetProgress(current, total, message, elapsed, options).Print(x =>
            {
                FConsole.Color(x.color).Write(x.text).ResetBackgroundColor().ResetColor();
            });
         
            if (current + 1 >= total)
            {
                if (options.AutoHide)
                {
                    // Clear console line
                    Console.SetCursorPosition(0, Console.CursorTop);
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(0, Console.CursorTop);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.CursorVisible = true;
            }
            return self;
        }

        private static ColoredStringBuilder GetProgress(
            int current,
            int total,
            string message,
            TimeSpan? elapsed,
            ProgressBarOptions options)
        {
            int barLength;
            var elapsedLength = elapsed.HasValue ? ProgressHelper.GetElapsedString(elapsed.Value).Length : 0;
            var accuracyLevel = ProgressHelper.SetAccuracy(options.Accuracy);

            if (options.BarSize != BarSize.Full && (int)options.BarSize < GetConsoleWindowWidth())
            {
                barLength = (int)options.BarSize;
            }
            else
            {
                barLength = GetConsoleWindowWidth();
            }

            // Make space for elapsed time.
            if (barLength + elapsedLength >= GetConsoleWindowWidth())
            {
                barLength -= elapsedLength;
            }

            if (options.BarSize == BarSize.Full && (options.Location == PercentLocation.Left || options.Location == PercentLocation.Right))
            {
                // This will shorten the bar to fit the progress value outside.
                barLength -= 5;

                if (accuracyLevel > 0)
                {
                    barLength -= (int)accuracyLevel + 1;  // Include decimal points and delimiter
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    barLength -= message.Length;
                }
            }

            decimal progressValue = ProgressHelper.GetProgressValue(current, total);
            string progressString = ProgressHelper.GetProgressString(progressValue, options.Location, accuracyLevel);


            var progressBuilder = new ColoredStringBuilder();
            var fillProgressBuilder = new StringBuilder();
            var emptyProgressBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(message))
            {
                progressBuilder.Append(options.Color, message);
            }

            progressBuilder.Append(options.Color, options.Location == PercentLocation.Left ? $"{progressString} " : string.Empty);

            for (byte i = 0; i < barLength; i++)
            {
                var position = barLength * progressValue / 100 - 1;
                if (progressValue > 0 && i <= position)
                {
                    fillProgressBuilder.Append(options.Character);
                }
                else
                {
                    emptyProgressBuilder.Append(options.BackgroundChar);
                }
            }

            progressBuilder.Append(options.Color, fillProgressBuilder.ToString());
            progressBuilder.Append(options.BackgroundColor, emptyProgressBuilder.ToString());

            progressBuilder.Append(options.Color, options.Location == PercentLocation.Right ? $" {progressString}" : string.Empty);

            if (elapsed.HasValue)
            {
                progressBuilder.Append(options.Color, ProgressHelper.GetElapsedString(elapsed.Value));
            }


            return progressBuilder;
        }


        private static int GetConsoleWindowWidth()
        {
            if (Console.LargestWindowWidth == 0)
            {
                // This does not run in a Console window (workaround for unit tests).
                return (int)BarSize.Full;
            }
            return Console.WindowWidth;
        }
    }
}


//public static void Write(int current, int total,
//            TimeSpan? elapsed = null,
//            char character = '\u2588',
//            ConsoleColor color = ConsoleColor.Yellow,
//            char backgroundChar = '\u2593',
//            ConsoleColor backgroundColor = ConsoleColor.DarkGray,
//            bool autoHide = false,
//            PercentLocation location = PercentLocation.Middle,
//            int accuracy = 0,
//            BarSize size = BarSize.Full)