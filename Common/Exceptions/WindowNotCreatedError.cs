using System;

namespace ArcadiaEngine.Common.Exceptions
{
    internal class WindowNotCreatedError : Exception
    {
        public WindowNotCreatedError(string message) : base(message) { }
        public WindowNotCreatedError() : base() { }
    }
}
