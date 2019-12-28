using AlienFruit.Otml;
using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AlienFruit.FluentConsole.AsciiArt.Tests
{
    public class AsciiPictureParserTests
    {
        private readonly Fixture fixture = new Fixture();

        private class SourceNode : OtmlNode
        {
            private readonly ValueNode value;
            public SourceNode(string source)
            {
                this.value = new ValueNode(source, true);
            }

            public override NodeType Type => NodeType.Object;

            protected override IEnumerable<OtmlNode> GetChildren() => Enumerable.Repeat(value, 1);

            protected override bool GetMultilineState() => false;

            protected override string GetName() => "source";

            protected override string GetValue() => null;
        }

        private class ValueNode : OtmlNode
        {

            private readonly bool isMultiline;
            private readonly string value;

            public ValueNode(string value, bool isMultiline)
            {
                this.value = value;
                this.isMultiline = isMultiline;
            }

            public override NodeType Type => NodeType.Value;

            protected override IEnumerable<OtmlNode> GetChildren() => Enumerable.Empty<OtmlNode>();

            protected override bool GetMultilineState() => this.isMultiline;

            protected override string GetName() => null;

            protected override string GetValue() => this.value;
        }

        [Fact]
        public void GetPicture_SouldReturnPictureWithAllTextLines_IfThereAreAnyEmptyLines()
        {
            //Arrange
            var pictureDom = new List<OtmlNode>();
            pictureDom.Add(new SourceNode($"a first text line{Environment.NewLine}{Environment.NewLine}a thrid line"));
            var parserMoq = new Mock<IParser>();
            parserMoq.Setup(x => x.Parse()).Returns(pictureDom);
            var foregroundColor = this.fixture.Create<ConsoleColor>();
            var backgroundColor = this.fixture.Create<ConsoleColor>();
            var parser = new AsciiPictureParser(parserMoq.Object, foregroundColor, backgroundColor) as IAsciiPictureParser;

            //Act
            var result = parser.GetPicture();

            //Assert
            result.Source[0].Should().Be("a first text line");
            result.Source[1].Should().Be(string.Empty);
            result.Source[2].Should().Be("a thrid line");
        }
    }
}
