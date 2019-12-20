using System.IO;

namespace AlienFruit.FluentConsole.AsciiArt
{
    public interface IAsciiPictureUnparser
    {
        void Unparse(AsciiPicture picture, Stream stream, bool leaveOpen = false);
    }
}
