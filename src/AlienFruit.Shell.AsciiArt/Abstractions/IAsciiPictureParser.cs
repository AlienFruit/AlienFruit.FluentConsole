using System;

namespace AlienFruit.Console.AsciiArt
{ 
    public interface IAsciiPictureParser : IDisposable
    {
        AsciiPicture GetPicture();
    }
}
