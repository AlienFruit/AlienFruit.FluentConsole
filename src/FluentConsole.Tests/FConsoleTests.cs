using AlienFruit.FluentConsole;
using AutoFixture;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace FConsoleTests
{
    public class FConsoleTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Write_ShouldWriteTextWithDefaultColor_IfChainIsBroke()
        {
            //Arrange
            var writer = new ConsoleTextWriter();
            var defaultBackgroundColor = Console.BackgroundColor;
            var defaultForegroundColor = Console.ForegroundColor;
            var newColor = this.fixture.Create<ConsoleColor>();
            var textWithNewColor = this.fixture.Create<string>();
            var textWithDefaultColor = this.fixture.Create<string>();
            Console.SetOut(writer);

            //Act
            FConsole.Color(newColor).Write(textWithNewColor);
            FConsole.Write(textWithDefaultColor);

            //Assert
            var firstRange = writer.TextRanges.ElementAt(0);
            firstRange.BackgroundColor.Should().Be(defaultBackgroundColor);
            firstRange.ForegroundColor.Should().Be(newColor);
            firstRange.Text.Should().Be(textWithNewColor);
            firstRange.EndOfLine.Should().BeFalse();
            var secondRange = writer.TextRanges.ElementAt(1);
            secondRange.BackgroundColor.Should().Be(defaultBackgroundColor);
            secondRange.ForegroundColor.Should().Be(defaultForegroundColor);
            secondRange.Text.Should().Be(textWithDefaultColor);
            secondRange.EndOfLine.Should().BeFalse();
        }

        [Fact]
        public void Write_ShouldWriteTextWithDefaultColor_AfterResetColor()
        {
            //Arrange
            var writer = new ConsoleTextWriter();
            var defaultBackgroundColor = Console.BackgroundColor;
            var defaultForegroundColor = Console.ForegroundColor;
            var newColor = this.fixture.Create<ConsoleColor>();
            var textWithNewColor = this.fixture.Create<string>();
            var textWithDefaultColor = this.fixture.Create<string>();
            Console.SetOut(writer);

            //Act
            FConsole.Color(newColor).Write(textWithNewColor).ResetColor().Write(textWithDefaultColor);

            //Assert
            var firstRange = writer.TextRanges.ElementAt(0);
            firstRange.BackgroundColor.Should().Be(defaultBackgroundColor);
            firstRange.ForegroundColor.Should().Be(newColor);
            firstRange.Text.Should().Be(textWithNewColor);
            firstRange.EndOfLine.Should().BeFalse();
            var secondRange = writer.TextRanges.ElementAt(1);
            secondRange.BackgroundColor.Should().Be(defaultBackgroundColor);
            secondRange.ForegroundColor.Should().Be(defaultForegroundColor);
            secondRange.Text.Should().Be(textWithDefaultColor);
            secondRange.EndOfLine.Should().BeFalse();
        }
    }
}
