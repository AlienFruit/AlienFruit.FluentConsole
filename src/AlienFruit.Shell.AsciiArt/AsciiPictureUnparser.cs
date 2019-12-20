using AlienFruit.Otml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlienFruit.Console.AsciiArt
{
    public class AsciiPictureUnparser : IAsciiPictureUnparser
    {
        private readonly IUnparser otmlUnparser;
        private readonly INodeFactory nodeFactory;

        public AsciiPictureUnparser(IUnparser unparser)
        {
            this.otmlUnparser = unparser;
            this.nodeFactory = unparser.GetNodeFactory();
        }

        public void Unparse(AsciiPicture picture, Stream stream, bool leaveOpen = false)
        {
            var tree = PictureToOtmlTree(picture);
            this.otmlUnparser.Unparse(tree, stream, leaveOpen);
        }

        private IEnumerable<OtmlNode> PictureToOtmlTree(AsciiPicture picture)
        {
            var resultTree = new List<OtmlNode>();

            var sourceNode = this.nodeFactory.CreateNode(NodeType.Object, "source");
            var sourceValue = this.nodeFactory.CreateValue(string.Join(Environment.NewLine, picture.Source), true);
            this.nodeFactory.AddChild(sourceNode, sourceValue);
            resultTree.Add(sourceNode);

            var styleNode = this.nodeFactory.CreateNode(NodeType.Object, "style", new[]
            {
                CreateProperty("background", picture.PictureStyle.Background.ToString()),
                CreateProperty("foreground", picture.PictureStyle.Foreground.ToString()),
                CreateProperty("margin-top", picture.PictureStyle.MarginTop.ToString()),
                CreateProperty("margin-bottom", picture.PictureStyle.MarginBottom.ToString()),
                CreateProperty("margin-left", picture.PictureStyle.MarginLeft.ToString())
            });
            resultTree.Add(styleNode);

            var formates = picture.Formates.Select(x => this.nodeFactory.CreateNode(NodeType.Property, "select", new[]
            {
                this.nodeFactory.CreateValue(x.Row.ToString()),
                this.nodeFactory.CreateValue(x.Start.ToString()),
                this.nodeFactory.CreateValue(x.Length.ToString()),
                this.nodeFactory.CreateValue(x.Color.ToString())
            }));
            resultTree.AddRange(formates);

            return resultTree;

            OtmlNode CreateProperty(string name, string value)
                => this.nodeFactory.CreateNode(NodeType.Property, name, new[]
                {
                    this.nodeFactory.CreateValue(value)
                });

        }
    }
}
