using System;

namespace AlienFruit.FluentConsole.AsciiArt
{ 
    public interface IAsciiPictureParser : IDisposable
    {
        AsciiPicture GetPicture();
    }
}
