using System;

namespace ArcadiaEngine.Common.Exceptions
{
    internal class ImageNotLoadedError : Exception
    {
        public ImageNotLoadedError() : base() { }
        public ImageNotLoadedError(string message) : base(message) { }
    }
}
