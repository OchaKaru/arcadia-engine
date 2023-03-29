using System;

namespace ArcadiaEngine.Common.Exceptions
{
    class InvalidLengthError : Exception
    {
        public InvalidLengthError() : base() { }
        public InvalidLengthError(string message) : base(message) { }
    }
}
