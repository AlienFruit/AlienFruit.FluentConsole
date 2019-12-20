using System;

namespace AlienFruit.FluentConsole
{
    public static partial class FConsole
    {
        private static ConsoleColor defaultForegroundColor = System.Console.ForegroundColor;
        private static ConsoleColor defaultBackgroundColor = System.Console.BackgroundColor;

        public static FluentConsole GetInstance() => new FluentConsole(); 

        public static FluentConsole Write<T>(T value)
        {
            ResetColors();
            Console.Write(value);
            return new FluentConsole();
        }

        public static FluentConsole WriteLine<T>(T value)
        {
            ResetColors();
            Console.WriteLine(value);
            return new FluentConsole();
        }

        public static FluentConsole Write<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            ResetColors();
            return new FluentConsole();
        }

        public static FluentConsole WriteLine<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            ResetColors();
            return new FluentConsole();
        }

        public static string ReadLine() => System.Console.ReadLine();

        public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey();

        public static FluentConsole NextLine()
        {
            ResetColors();
            Console.Write(Environment.NewLine);
            return new FluentConsole();
        }

        public static FluentConsole Color(ConsoleColor color) => new FluentConsole().Color(color);

        public static FluentConsole BackgroundColor(ConsoleColor color) => new FluentConsole().BackgroundColor(color);

        public static FluentConsole ResetColors()
        {
            Console.ForegroundColor = defaultForegroundColor;
            Console.BackgroundColor = defaultBackgroundColor;
            return new FluentConsole();
        }

        public static void SetForegroundColor(ConsoleColor color) => defaultForegroundColor = System.Console.ForegroundColor = color;
        
        public static void SetBackgroundColor(ConsoleColor color) => defaultBackgroundColor = System.Console.BackgroundColor = color;

        public class FluentConsole
        {
            private readonly ConsoleColor startForegroundColor;
            private readonly ConsoleColor startBackgroundColor;
            
            public FluentConsole()
            {
                this.startForegroundColor = Console.ForegroundColor;
                this.startBackgroundColor = Console.BackgroundColor;
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
                FConsole.Write(value);
                return this;
            }

            public FluentConsole WriteLine<T>(T value)
            {
                FConsole.WriteLine(value);
                return this;
            }

            public FluentConsole NextLine()
            {
                FConsole.NextLine();
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
