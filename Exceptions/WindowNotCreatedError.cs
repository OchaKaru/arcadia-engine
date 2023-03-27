using System;

namespace ArcadiaEngine.Exceptions {
    internal class WindowNotCreatedError : Exception {
        public WindowNotCreatedError(string message) : base(message) {}
        public WindowNotCreatedError() : base() {}
    }
}
