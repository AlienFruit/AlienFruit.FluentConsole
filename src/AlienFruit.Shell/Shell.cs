using AlienFruit.Otml.Factories;
using System;

namespace AlienFruit.Console
{
    public static partial class Shell
    {
        private static ConsoleColor defaultForegroundColor = System.Console.ForegroundColor;
        private static ConsoleColor defaultBackgroundColor = System.Console.BackgroundColor;

        public static FluentShell GetInstance() => new FluentShell(); 

        public static FluentShell Write<T>(T value)
        {
            ResetColors();
            System.Console.Write(value);
            return new FluentShell();
        }

        public static FluentShell WriteLine<T>(T value)
        {
            ResetColors();
            System.Console.WriteLine(value);
            return new FluentShell();
        }

        public static FluentShell Write<T>(T value, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.Write(value);
            ResetColors();
            return new FluentShell();
        }

        public static FluentShell WriteLine<T>(T value, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(value);
            ResetColors();
            return new FluentShell();
        }

        public static string ReadLine() => System.Console.ReadLine();

        public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey();

        public static FluentShell NextLine()
        {
            ResetColors();
            System.Console.Write(Environment.NewLine);
            return new FluentShell();
        }

        public static FluentShell Color(ConsoleColor color) => new FluentShell().Color(color);

        public static FluentShell BackgroundColor(ConsoleColor color) => new FluentShell().BackgroundColor(color);

        public static FluentShell ResetColors()
        {
            System.Console.ForegroundColor = defaultForegroundColor;
            System.Console.BackgroundColor = defaultBackgroundColor;
            return new FluentShell();
        }

        public static void SetForegroundColor(ConsoleColor color) => defaultForegroundColor = System.Console.ForegroundColor = color;
        
        public static void SetBackgroundColor(ConsoleColor color) => defaultBackgroundColor = System.Console.BackgroundColor = color;

        public class FluentShell
        {
            private readonly ConsoleColor startForegroundColor;
            private readonly ConsoleColor startBackgroundColor;
            
            public FluentShell()
            {
                this.startForegroundColor = System.Console.ForegroundColor;
                this.startBackgroundColor = System.Console.BackgroundColor;
            }

            public FluentShell Color(ConsoleColor color)
            {
                System.Console.ForegroundColor = color;
                return this;
            }

            public FluentShell BackgroundColor(ConsoleColor color)
            {
                System.Console.BackgroundColor = color;
                return this;
            }

            public FluentShell Write<T>(T value)
            {
                Shell.Write(value);
                return this;
            }

            public FluentShell WriteLine<T>(T value)
            {
                Shell.WriteLine(value);
                return this;
            }

            public FluentShell NextLine()
            {
                Shell.NextLine();
                return this;
            }

            public FluentShell ResetColor()
            {
                System.Console.ForegroundColor = this.startForegroundColor;
                return this;
            }

            public FluentShell ResetBackgroundColor()
            {
                System.Console.BackgroundColor = this.startBackgroundColor;
                return this;
            }

        }

    }
}
