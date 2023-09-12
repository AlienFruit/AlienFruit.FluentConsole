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

        /// <summary>
        /// Get FluentConsole instance, necessary if you need to use any extension
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole GetInstance()
        {
            ResetColors();
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">Object</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole Write<T>(T value)
        {
            ResetColors();
            Console.Write(value);
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">>Object</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole WriteLine<T>(T value)
        {
            ResetColors();
            Console.WriteLine(value);
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">Object</param>
        /// <param name="color">Foreground text color</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole Write<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            ResetColors();
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">Object</param>
        /// <param name="color">>Foreground text color</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole WriteLine<T>(T value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            ResetColors();
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available.</returns>
        public static string ReadLine() => Console.ReadLine();

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window.
        /// </summary>
        /// <returns>
        /// An object that describes the System.ConsoleKey constant and Unicode character,
        /// if any, that correspond to the pressed console key. The System.ConsoleKeyInfo
        /// object also describes, in a bitwise combination of System.ConsoleModifiers values,
        /// whether one or more Shift, Alt, or Ctrl modifier keys was pressed simultaneously
        /// with the console key.
        /// </returns>
        public static ConsoleKeyInfo ReadKey() => Console.ReadKey();

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole NextLine()
        {
            ResetColors();
            Console.WriteLine();
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Set foreground text color of FluentConsole instance
        /// </summary>
        /// <param name="color">new foreground color</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole Color(ConsoleColor color) => fluentConsoleFactory().Color(color);


        /// <summary>
        /// Set background text color of FluentConsole instance
        /// </summary>
        /// <param name="color">new background color</param>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole BackgroundColor(ConsoleColor color) => fluentConsoleFactory().BackgroundColor(color);

        /// <summary>
        /// Reset instanse colors to default
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public static FluentConsole ResetColors()
        {
            Console.ForegroundColor = defaultForegroundColor;
            Console.BackgroundColor = defaultBackgroundColor;
            return fluentConsoleFactory();
        }

        /// <summary>
        /// Default foreground color which apply after ResetColors
        /// </summary>
        /// <param name="color">new default color</param>
        public static void SetDefaultForegroundColor(ConsoleColor color) => defaultForegroundColor = Console.ForegroundColor = color;

        /// <summary>
        /// Default background color which apply after ResetColors
        /// </summary>
        /// <param name="color">new default color</param>
        public static void SetDefaultBackgroundColor(ConsoleColor color) => defaultBackgroundColor = Console.BackgroundColor = color;
    }
}
