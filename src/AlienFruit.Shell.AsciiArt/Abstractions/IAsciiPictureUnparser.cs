using System.IO;

namespace AlienFruit.Console.AsciiArt
{
    public interface IAsciiPictureUnparser
    {
        void Unparse(AsciiPicture picture, Stream stream, bool leaveOpen = false);
    }
}
