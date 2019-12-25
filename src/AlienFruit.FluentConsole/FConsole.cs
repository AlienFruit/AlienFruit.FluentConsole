using System;

namespace AlienFruit.FluentConsole
{
    public static partial class FConsole
    {
        private static ConsoleColor defaultForegroundColor;
        private static ConsoleColor defaultBackgroundColor;

        private static Func<FluentConsole> fluentConsoleFactory;

        static FConsole()
        {
            defaultForegroundColor = Console.ForegroundColor;
            defaultBackgroundColor = Console.BackgroundColor;
            fluentConsoleFactory = () => new FluentConsole(Console.ForegroundColor, Console.BackgroundColor);
        }

        public static FluentConsole GetInstance()
        {
            ResetColors();
            return fluentConsoleFactory();
        }

        public static FluentConsole Write<T>(T value)
        {
            ResetColors();
            Console.Write(value);
            return fluentConsoleFactory();
        }

        public static FluentConsole WriteLine<T>(T value)
        {
            ResetColors();
            Console.WriteLine(value);
            return fluentConsoleFactory();
        }

        public static FluentConsole Write<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            ResetColors();
            return fluentConsoleFactory();
        }

        public static FluentConsole WriteLine<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            ResetColors();
            return fluentConsoleFactory();
        }

        public static string ReadLine() => Console.ReadLine();

        public static ConsoleKeyInfo ReadKey() => Console.ReadKey();

        public static FluentConsole NextLine()
        {
            ResetColors();
            Console.WriteLine();
            return fluentConsoleFactory();
        }

        public static FluentConsole Color(ConsoleColor color) => fluentConsoleFactory().Color(color);

        public static FluentConsole BackgroundColor(ConsoleColor color) => fluentConsoleFactory().BackgroundColor(color);

        public static FluentConsole ResetColors()
        {
            Console.ForegroundColor = defaultForegroundColor;
            Console.BackgroundColor = defaultBackgroundColor;
            return fluentConsoleFactory();
        }

        public static void SetForegroundColor(ConsoleColor color) => defaultForegroundColor = System.Console.ForegroundColor = color;
        
        public static void SetBackgroundColor(ConsoleColor color) => defaultBackgroundColor = System.Console.BackgroundColor = color;

        public class FluentConsole
        {
            private readonly ConsoleColor startForegroundColor;
            private readonly ConsoleColor startBackgroundColor;
            
            public FluentConsole(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
            {
                this.startForegroundColor = foregroundColor;
                this.startBackgroundColor = backgroundColor;
            }

            public FluentConsole Color(ConsoleColor color)
            {
                Console.ForegroundColor = color;
                return this;
            }

            public FluentConsole BackgroundColor(ConsoleColor color)
            {
                Console.BackgroundColor = color;
                return this;
            }

            public FluentConsole Write<T>(T value)
            {
                Console.Write(value);
                return this;
            }

            public FluentConsole WriteLine<T>(T value)
            {
                Console.WriteLine(value);
                return this;
            }

            public FluentConsole NextLine()
            {
                Console.WriteLine();
                return this;
            }

            public FluentConsole ResetColor()
            {
                Console.ForegroundColor = this.startForegroundColor;
                return this;
            }

            public FluentConsole ResetBackgroundColor()
            {
                Console.BackgroundColor = this.startBackgroundColor;
                return this;
            }

        }

    }
}
