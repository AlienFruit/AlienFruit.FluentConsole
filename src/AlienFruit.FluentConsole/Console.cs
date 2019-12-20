using System;

namespace AlienFruit.FluentConsole
{
    public static partial class Console
    {
        private static ConsoleColor defaultForegroundColor = System.Console.ForegroundColor;
        private static ConsoleColor defaultBackgroundColor = System.Console.BackgroundColor;

        public static FluentConsole GetInstance() => new FluentConsole(); 

        public static FluentConsole Write<T>(T value)
        {
            ResetColors();
            System.Console.Write(value);
            return new FluentConsole();
        }

        public static FluentConsole WriteLine<T>(T value)
        {
            ResetColors();
            System.Console.WriteLine(value);
            return new FluentConsole();
        }

        public static FluentConsole Write<T>(T value, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.Write(value);
            ResetColors();
            return new FluentConsole();
        }

        public static FluentConsole WriteLine<T>(T value, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(value);
            ResetColors();
            return new FluentConsole();
        }

        public static string ReadLine() => System.Console.ReadLine();

        public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey();

        public static FluentConsole NextLine()
        {
            ResetColors();
            System.Console.Write(Environment.NewLine);
            return new FluentConsole();
        }

        public static FluentConsole Color(ConsoleColor color) => new FluentConsole().Color(color);

        public static FluentConsole BackgroundColor(ConsoleColor color) => new FluentConsole().BackgroundColor(color);

        public static FluentConsole ResetColors()
        {
            System.Console.ForegroundColor = defaultForegroundColor;
            System.Console.BackgroundColor = defaultBackgroundColor;
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
                this.startForegroundColor = System.Console.ForegroundColor;
                this.startBackgroundColor = System.Console.BackgroundColor;
            }

            public FluentConsole Color(ConsoleColor color)
            {
                System.Console.ForegroundColor = color;
                return this;
            }

            public FluentConsole BackgroundColor(ConsoleColor color)
            {
                System.Console.BackgroundColor = color;
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
                Console.NextLine();
                return this;
            }

            public FluentConsole ResetColor()
            {
                System.Console.ForegroundColor = this.startForegroundColor;
                return this;
            }

            public FluentConsole ResetBackgroundColor()
            {
                System.Console.BackgroundColor = this.startBackgroundColor;
                return this;
            }

        }

    }
}
