using System;

namespace ArcadiaEngine.Exceptions {
    class InvalidLengthError : Exception {
        public InvalidLengthError() : base() {}
        public InvalidLengthError(string message) : base(message) {}
    }
}
