using System;

namespace AlienFruit.FluentConsole
{
    public class FluentConsole
    {
        private readonly ConsoleColor startForegroundColor;
        private readonly ConsoleColor startBackgroundColor;

        public FluentConsole(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.startForegroundColor = foregroundColor;
            this.startBackgroundColor = backgroundColor;
        }


        /// <summary>
        /// Set foreground text color of FluentConsole instance
        /// </summary>
        /// <param name="color">new foreground color</param>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            return this;
        }

        /// <summary>
        /// Set background text color of FluentConsole instance
        /// </summary>
        /// <param name="color">new background color</param>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole BackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            return this;
        }

        /// <summary>
        /// Writes the text representation of the specified object to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">Object</param>
        /// <param name="color">Foreground text color</param>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole Write<T>(T value)
        {
            Console.Write(value);
            return this;
        }

        /// <summary>
        /// Writes the text representation of the specified object, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="value">Object</param>
        /// <param name="color">>Foreground text color</param>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole WriteLine<T>(T value)
        {
            Console.WriteLine(value);
            return this;
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole NextLine()
        {
            Console.WriteLine();
            return this;
        }

        /// <summary>
        /// Reset instanse colos to default
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole ResetColors()
        {
            Console.ForegroundColor = this.startForegroundColor;
            Console.BackgroundColor = this.startBackgroundColor;
            return this;
        }

        /// <summary>
        /// Reset instanse foreground color to default
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole ResetColor()
        {
            Console.ForegroundColor = this.startForegroundColor;
            return this;
        }

        /// <summary>
        /// Reset instanse background color to default
        /// </summary>
        /// <returns>FluentConsole instance</returns>
        public FluentConsole ResetBackgroundColor()
        {
            Console.BackgroundColor = this.startBackgroundColor;
            return this;
        }
    }
}
