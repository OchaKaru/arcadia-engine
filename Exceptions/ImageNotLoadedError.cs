using System;

namespace ArcadiaEngine.Exceptions {
    internal class ImageNotLoadedError : Exception {
        public ImageNotLoadedError() : base() {}
        public ImageNotLoadedError(string message) : base(message) {}
    }
}
